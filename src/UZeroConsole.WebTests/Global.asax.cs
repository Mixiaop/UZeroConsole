using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using StackExchange.Profiling;
using U;

namespace UZeroConsole.WebTests
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            new U.UStarter().Startup();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            MiniProfiler.Start();
        }

        protected void Application_EndRequest(object sender, EventArgs e) {
            MiniProfiler.Stop();
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //var exception = Server.GetLastError();
            //var loggingService = UPrimeEngine.Instance.Resolve<ILoggingClientService>();
            //var httpException = exception as HttpException;
            //if (httpException != null && httpException.GetHttpCode() != 404)
            //{
            //    loggingService.HandleExceptionAsync(exception); //log.youzy.cn
            //}
            //else
            //{
                //process 404 HTTP errors
                //var webHelper = UPrimeEngine.Instance.Resolve<IWebHelper>();
                //if (!WebHelper.IsStaticResource(this.Request))
                //{
                //    Response.Clear();
                //    Server.ClearError();
                //    Response.TrySkipIisCustomErrors = true;

                //    //Response.Redirect("/page-not-found");
                //}
            //}
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            
        }
    }
}