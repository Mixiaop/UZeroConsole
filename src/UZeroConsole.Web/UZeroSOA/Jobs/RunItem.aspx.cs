using System;
using U;
using U.Utilities.Web;
using UZeroConsole.Services.Jobs;
namespace UZeroConsole.Web.UZeroSOA.Jobs
{
    public partial class RunItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var jobId = WebHelper.GetInt("jobId", 0);
            var remoteUrl = WebHelper.GetString("remoteUrl");
            var desc = WebHelper.GetString("desc");

            IRemoteJobService jobService = UPrimeEngine.Instance.Resolve<IRemoteJobService>();

            var job = jobService.Get(jobId);

            if (job != null && remoteUrl.IsNotNullOrEmpty()) {
                jobService.RunItem(job, remoteUrl, desc);
            }
        }
    }
}