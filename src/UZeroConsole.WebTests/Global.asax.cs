using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using U;
using UZeroConsole.Logging;
namespace UZeroConsole.WebTests
{
    public class Global : U.Web.UWebApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            base.Application_Start(sender, e);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected override void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            var loggingService = UPrimeEngine.Instance.Resolve<ILoggingService>();
            var httpException = exception as HttpException;
            if (httpException != null && httpException.GetHttpCode() != 404)
            {
                loggingService.HandleExceptionAsync(exception); //log.youzy.cn
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

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}