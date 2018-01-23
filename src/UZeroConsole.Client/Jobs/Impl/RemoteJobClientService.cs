using System.Collections.Generic;
using System.Threading.Tasks;
using U.Utilities.Net;

namespace UZeroConsole.Client.Jobs.Impl
{
    public class RemoteJobClientService : BaseClientService, IRemoteJobClientService
    {
        public void RunItem(int jobId, string remoteUrl, string desc)
        {
            var soaUrl = CombineUrl(Settings.JobsSoaHost, "/UZeroSOA/Jobs/RunItem.aspx");

            Dictionary<string, string> formData = new Dictionary<string, string>();
            formData.Add("jobId", jobId.ToString());
            formData.Add("remoteUrl", remoteUrl.Trim());
            formData.Add("desc", desc.Trim());

            WebRequestHelper.HttpPost(soaUrl, formData);
        }

        public Task RunItemAsync(int jobId, string remoteUrl, string desc)
        {
            RunItem(jobId, remoteUrl, desc);
            return Task.FromResult(0);
        }
    }
}
