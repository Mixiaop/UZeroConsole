using System;
using System.Linq;
using U.BackgroundJobs;
using U.Application.Services;
using U.Application.Services.Dto;
using UZeroConsole.Domain.Jobs;

namespace UZeroConsole.Services.Jobs
{
    public class RemoteJobService : IRemoteJobService
    {
        private IBackgroundJobManager _backgroundJobManager;
        private IRemoteJobRepository _jobRepository;
        public RemoteJobService(IRemoteJobRepository jobRepository, IBackgroundJobManager backgroundJobManager)
        {
            _jobRepository = jobRepository;
            _backgroundJobManager = backgroundJobManager;
        }

        /// <summary>
        /// 查询并获取任务列表
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="executing"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagedResultDto<RemoteJob> Query(string keywords, bool? executing = null, int pageIndex = 1, int pageSize = 20)
        {
            var query = _jobRepository.GetAll();

            if (keywords.IsNullOrEmpty()) {
                query = query.Where(x => x.Key.Contains(keywords) || x.Name.Contains(keywords));
            }

            if (executing.HasValue) {
                if (executing.Value)
                    query = query.Where(x => x.IsExecuting == true);
                else
                    query = query.Where(x => x.IsExecuting == false);
            }

            query = query.OrderByDescending(x => x.CreationTime);
            var count = query.Count();
            var list = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return new PagedResultDto<RemoteJob>(count, list);

        }

        /// <summary>
        /// 获取一个任务
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public RemoteJob Get(int jobId) {
            return _jobRepository.Get(jobId);
        }

        /// <summary>
        /// 创建一个任务
        /// </summary>
        /// <param name="key">任务KEY（唯一）</param>
        /// <param name="name">名称</param>
        /// <param name="url">URL路径</param>
        /// <param name="desc">描述</param>
        /// <param name="jobType">类型，默认为循环任务</param>
        /// <param name="recurringSeconds">循环任务的间隔（秒）</param>
        /// <param name="atTime">定时任务的触发的时间</param>
        /// <returns></returns>
        public RemoteJob CreateJob(string key, string name, string url, string desc = "", RemoteJobType jobType = RemoteJobType.Recurring, int recurringSeconds = 300, DateTime? atTime = null) {
            RemoteJob job = new RemoteJob();
            job.Key = key;
            job.Name = name;
            job.Url = url;
            job.Desc = desc;
            job.Type = jobType;
            job.RecurringSeconds = recurringSeconds;
            job.AtTime = atTime;

            job.Id = _jobRepository.InsertAndGetId(job);

            return job;
        }

        /// <summary>
        /// 运行任务
        /// </summary>
        /// <param name="job"></param>
        public void Run(RemoteJob job) {
            string appJobId = "";
            switch (job.Type) { 
                case RemoteJobType.General:
                    appJobId = _backgroundJobManager.Enqueue<URemoteJob, int>(job.Id);
                    break;
                case RemoteJobType.AtTime:
                    if (job.AtTime.HasValue)
                        appJobId = _backgroundJobManager.Schedule<URemoteJob, int>(job.Id, job.AtTime.Value);
                    break;
                case RemoteJobType.Recurring:
                    //float minutes = job.RecurringSeconds / 60f;
                    //appJobId = _backgroundJobManager.AddRecurringJob<URemoteJob, int>(job.Id, string.Format("0/{0} * * * *", minutes));
                    //Timeout方式
                    DateTime time = DateTime.Now.AddSeconds(job.RecurringSeconds);
                    appJobId = _backgroundJobManager.Schedule<URemoteJob, int>(job.Id, time);
                    break;
            }

            //Hangfire to RemoteJob
            if (appJobId.IsNotNullOrEmpty())
            {
                job.AppJobId = appJobId;
                _jobRepository.Update(job);
            }
        }

        /// <summary>
        /// 执行中改变状态
        /// </summary>
        /// <param name="job"></param>
        public void Executing(RemoteJob job) {
            job.IsExecuting = true;
            _jobRepository.Update(job);
        }

        /// <summary>
        /// 执行完成改变状态
        /// </summary>
        /// <param name="job"></param>
        public void ExecuteComplete(RemoteJob job) {
            job.IsExecuting = false;
            job.LastSuccessTime = DateTime.Now;
            _jobRepository.Update(job);

            //Timeout运行
            if (job.Type == RemoteJobType.Recurring) {
                Run(job);
            }
        }

        /// <summary>
        /// 执行出错了记录错误
        /// </summary>
        /// <param name="job"></param>
        /// <param name="errorMessage"></param>
        public void ExecuteError(RemoteJob job, string errorMessage) {
            job.LastErrorDesc = errorMessage;
            job.LastErrorTime = DateTime.Now;
            _jobRepository.Update(job);
        }

        /// <summary>
        /// 删除一个任务
        /// </summary>
        /// <param name="jobId"></param>
        public void DeleteJob(int jobId) {
            var job = Get(jobId);
            if (job != null && job.AppJobId.IsNotNullOrEmpty()) {
                _backgroundJobManager.Delete(job.AppJobId);
            }
            _jobRepository.Delete(jobId);

        }
    }
}
