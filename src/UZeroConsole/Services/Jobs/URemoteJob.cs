using System;
using System.Net;
using U;
using U.BackgroundJobs;
using U.Logging;

namespace UZeroConsole.Services.Jobs
{
    public class URemoteJob : BackgroundJob<int>, U.Dependency.ITransientDependency
    {
        IRemoteJobService _remoteJobService = UPrimeEngine.Instance.Resolve<IRemoteJobService>();
        public override void Execute(int args)
        {
            var job = _remoteJobService.Get(args);
            if (job != null)
            {
                _remoteJobService.Executing(job);
                try
                {
                    using (var wc = new WebClient())
                    {
                        var message = wc.DownloadString(job.Url);
                        _remoteJobService.ExecuteComplete(job);
                    }
                }
                catch (Exception ex) {
                    _remoteJobService.ExecuteError(job, ex.Message);
                }
            }
            else {
                LogHelper.Logger.Error("=================》【UZeroRemoteJob】出错了：未找到任务【" + args + "】");
            }
        }
    }
}