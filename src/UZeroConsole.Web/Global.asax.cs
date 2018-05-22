using System;
using System.Web;
using U;
using U.Logging;
using UZeroConsole.Monitoring;
using UZeroConsole.Web.Infrastructure;

namespace UZeroConsole.Web
{
    public class Global :  HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            new UStarter().Startup();

            UPrime.UPrimeStarter.Create<UZeroConsoleWebModule>(
            
            ).Initialize();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            var logger = UPrimeEngine.Instance.Resolve<ILogger>();
            var httpException = exception as HttpException;
            if (httpException != null && httpException.GetHttpCode() != 404)
            {
                logger.Error(httpException.Message, httpException); //本地日志
            }
            else
            {
                //process 404 HTTP errors
                //var webHelper = UPrimeEngine.Instance.Resolve<IWebHelper>();
                //if (!WebHelper.IsStaticResource(this.Request))
                //{
                //    Response.Clear();
                //    Server.ClearError();
                //    Response.TrySkipIisCustomErrors = true;

                //    //Response.Redirect("/page-not-found");
                //}
            }
        }

        protected void Application_End() {
            PollingEngine.StopPolling();
        }
    }
}