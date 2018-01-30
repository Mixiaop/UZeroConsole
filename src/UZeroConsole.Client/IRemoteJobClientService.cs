using System.Threading.Tasks;

namespace UZeroConsole.Client
{
    public interface IRemoteJobClientService : IClientService
    {
        void RunItem(int jobId, string remoteUrl, string desc);

        Task RunItemAsync(int jobId, string remoteUrl, string desc);
    }
}
