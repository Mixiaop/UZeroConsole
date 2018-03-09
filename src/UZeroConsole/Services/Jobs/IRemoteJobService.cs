using System;
using U.Application.Services;
using U.Application.Services.Dto;
using UZeroConsole.Domain.Jobs;

namespace UZeroConsole.Services.Jobs
{
    /// <summary>
    /// 远程Job服务，
    /// 添加一个URL能访问的任务（如：www.youzy.cn/jobs/keepalive），定时或循环去调用它
    /// </summary>
    public interface IRemoteJobService : IApplicationService
    {
        /// <summary>
        /// 查询并获取任务列表
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="tags"></param>
        /// <param name="executing"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        PagedResultDto<RemoteJob> Query(string keywords, string tags = "", bool? executing = null, int pageIndex = 1, int pageSize = 20);

        /// <summary>
        /// 获取一个任务
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        RemoteJob Get(int jobId);

        /// <summary>
        /// 创建一个任务
        /// </summary>
        /// <param name="key">任务KEY（唯一）</param>
        /// <param name="name">名称</param>
        /// <param name="url">URL路径</param>
        /// <param name="parentId"></param>
        /// <param name="desc">描述</param>
        /// <param name="jobType">类型，默认为循环任务</param>
        /// <param name="recurringSeconds">循环任务的间隔（秒）</param>
        /// <param name="atTime">定时任务的触发的时间</param>
        /// <param name="tags"></param>
        /// <returns></returns>
        RemoteJob CreateJob(string key, string name, string url, int parentId = 0, string desc = "", RemoteJobType jobType = RemoteJobType.Recurring, int recurringSeconds = 300, DateTime? atTime = null, string tags = "");

        /// <summary>
        /// 运行任务
        /// </summary>
        /// <param name="job"></param>
        /// <param name="isFirst"></param>
        void Run(RemoteJob job, bool isFirst = false);

        /// <summary>
        /// 运行任务项
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="url"></param>
        /// <param name="desc"></param>
        void RunItem(RemoteJob parent, string url, string desc);

        /// <summary>
        /// 执行中改变状态
        /// </summary>
        /// <param name="job"></param>
        void Executing(RemoteJob job);

        /// <summary>
        /// 执行完成改变状态
        /// </summary>
        /// <param name="job"></param>
        void ExecuteComplete(RemoteJob job);

        /// <summary>
        /// 执行出错了记录错误
        /// </summary>
        /// <param name="job"></param>
        /// <param name="errorMessage"></param>
        void ExecuteError(RemoteJob job, string errorMessage);

        /// <summary>
        /// 删除一个任务
        /// </summary>
        /// <param name="jobId"></param>
        void DeleteJob(int jobId);
    }
}
