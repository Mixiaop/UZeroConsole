using System;
using System.Linq;
using U.BackgroundJobs;
using U.Application.Services;
using U.Application.Services.Dto;
using UZeroConsole.Domain;
using UZeroConsole.Domain.Jobs;

namespace UZeroConsole.Services.Jobs
{
    public class RemoteJobService : IRemoteJobService
    {
        private IBackgroundJobManager _backgroundJobManager;
        private IRemoteJobRepository _jobRepository;

        private ITagService _tagService;
        public RemoteJobService(IBackgroundJobManager backgroundJobManager, IRemoteJobRepository jobRepository, ITagService tagService)
        {
            _backgroundJobManager = backgroundJobManager;
            _jobRepository = jobRepository;

            _tagService = tagService;
        }

        /// <summary>
        /// 查询并获取任务列表
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="tags"></param>
        /// <param name="executing"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagedResultDto<RemoteJob> Query(string keywords, string tags = "", bool? executing = null, int pageIndex = 1, int pageSize = 20)
        {
            var query = _jobRepository.GetAll().Where(x => x.ParentId == 0);

            if (keywords.IsNotNullOrEmpty())
            {
                query = query.Where(x => x.Key.Contains(keywords) || x.Name.Contains(keywords));
            }

            if (tags.IsNotNullOrEmpty())
            {
                query = query.Where(x => x.Tags.Contains(tags));
            }

            if (executing.HasValue)
            {
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
        public RemoteJob Get(int jobId)
        {
            return _jobRepository.Get(jobId);
        }

        public RemoteJob CreateJob(string key, string name, string url, int parentId = 0, string desc = "", RemoteJobType jobType = RemoteJobType.Recurring, int recurringSeconds = 300, DateTime? atTime = null, string tags = "")
        {
            RemoteJob job = new RemoteJob();
            job.Key = key;
            job.Name = name;
            job.Url = url;
            job.Desc = desc;
            job.Type = jobType;
            job.RecurringSeconds = recurringSeconds;
            job.AtTime = atTime;
            job.Tags = tags;
            job.ParentId = parentId;
            if (job.Tags.IsNotNullOrEmpty())
            {
                job.Tags = job.Tags.Replace("，", ",");
                _tagService.UpdateTags(TagType.Job, job.Tags);
            }

            job.Id = _jobRepository.InsertAndGetId(job);

            return job;
        }

        /// <summary>
        /// 运行任务
        /// </summary>
        /// <param name="job"></param>
        /// <param name="isFirst">是否首次点击运行</param>
        public void Run(RemoteJob job, bool isFirst = false)
        {
            string appJobId = "";
            switch (job.Type)
            {
                case RemoteJobType.General:
                    appJobId = _backgroundJobManager.Enqueue<URemoteJob, int>(job.Id);
                    break;
                case RemoteJobType.AtTime:
                    if (job.AtTime.HasValue)
                        appJobId = _backgroundJobManager.Schedule<URemoteJob, int>(job.Id, job.AtTime.Value);
                    break;
                case RemoteJobType.AtTimeRecurring:
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
                if (isFirst) {
                    job.LastSuccessTime = null;
                    job.LastErrorTime = null;
                    job.LastErrorDesc = "";
                }
                _jobRepository.Update(job);
            }
        }

        /// <summary>
        /// 运行任务项
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="url"></param>
        /// <param name="desc"></param>
        public void RunItem(RemoteJob parent, string url, string desc)
        {
            if (parent != null)
            {
                var job = CreateJob(parent.Key + "_item", "", url, parent.Id, desc, RemoteJobType.General, 0);
                Run(job);
            }
        }

        /// <summary>
        /// 执行中改变状态
        /// </summary>
        /// <param name="job"></param>
        public void Executing(RemoteJob job)
        {
            job.IsExecuting = true;
            _jobRepository.Update(job);
        }

        /// <summary>
        /// 执行完成改变状态
        /// </summary>
        /// <param name="job"></param>
        public void ExecuteComplete(RemoteJob job)
        {
            job.IsExecuting = false;
            job.LastSuccessTime = DateTime.Now;
            _jobRepository.Update(job);

            //Timeout运行
            if (job.Type == RemoteJobType.Recurring || job.Type == RemoteJobType.AtTimeRecurring)
            {
                Run(job);
            }
        }

        /// <summary>
        /// 执行出错了记录错误
        /// </summary>
        /// <param name="job"></param>
        /// <param name="errorMessage"></param>
        public void ExecuteError(RemoteJob job, string errorMessage)
        {
            job.LastErrorDesc = errorMessage;
            job.LastErrorTime = DateTime.Now;
            _jobRepository.Update(job);

            //继续执行
            if (job.Type == RemoteJobType.Recurring || job.Type == RemoteJobType.AtTimeRecurring)
            {
                Run(job);
            }
        }

        /// <summary>
        /// 删除一个任务
        /// </summary>
        /// <param name="jobId"></param>
        public void DeleteJob(int jobId)
        {
            var job = Get(jobId);
            if (job != null && job.AppJobId.IsNotNullOrEmpty())
            {
                _backgroundJobManager.Delete(job.AppJobId);
            }
            _jobRepository.Delete(jobId);

        }


    }
}
