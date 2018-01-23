using U;
namespace UZeroConsole.Client
{
    public abstract class BaseClientService : IClientService
    {
        public ClientSettings Settings;
        public BaseClientService() {
            this.Settings = UPrimeEngine.Instance.Resolve<ClientSettings>();
        }


        public string CombineUrl(string host, string url) {
            var returnUrl = "";
            if (host.EndsWith("/"))
            {
                returnUrl = host + url.TrimStart('/');
            }
            else {
                returnUrl = host + "/" + url.TrimStart('/');
            }

            if (!returnUrl.Contains("http://")) {
                returnUrl += "http://" + returnUrl;
            }

            return returnUrl;
        }
    }
}
