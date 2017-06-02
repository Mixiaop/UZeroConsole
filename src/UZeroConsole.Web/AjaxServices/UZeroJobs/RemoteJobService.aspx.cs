using System;
using AjaxPro;
using U;
using UZeroConsole.Services.Jobs;
namespace UZeroConsole.Web.AjaxServices.UZeroJobs
{

    [AjaxNamespace("RemoteJobService")]
    public partial class RemoteJobService : System.Web.UI.Page
    {
        IRemoteJobService _remoteJobService = UPrimeEngine.Instance.Resolve<IRemoteJobService>();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [AjaxMethod]
        public void Delete(int jobId)
        {
            _remoteJobService.DeleteJob(jobId);
        }

        [AjaxMethod]
        public void Run(int jobId) {
            var job = _remoteJobService.Get(jobId);
            if (job != null)
            {
                _remoteJobService.Run(job);
            }
        }
    }
}