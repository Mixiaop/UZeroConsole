using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using U;
//using UZeroConsole.Logging;
using UZeroConsole.Services.Logging;

namespace UZeroConsole.Web._Tests
{
    public partial class LoggingTests : System.Web.UI.Page
    {
        //ILoggingClientService loggingService = UPrimeEngine.Instance.Resolve<ILoggingClientService>();
        IActionLogService actionLogService = UPrimeEngine.Instance.Resolve<IActionLogService>();
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    throw new HttpException("未找到对象");
            //}
            //catch (HttpException ex)
            //{
            //    var a = 1;

            //    Response.Write(ex.StackTrace);
            //    Response.Write("<br />=======================================<br />");
            //    Response.Write(ex.Message);
            //    Response.Write("<br />=======================================<br />");
            //    Response.Write(ex.ToString());
            //    Response.Write("<br />=======================================<br />");
            //    Response.Write(ex.Source);
            //    Response.Write("<br />=======================================<br />");
            //    Response.Write(ex.InnerException == null);
            //    Response.Write("<br />=======================================<br />");

            //    loggingService.HandleExceptionAsync(ex);
            //    //loggingService.HandleException(ex);

            //}


            var list = actionLogService.GetTopLogs(12, "6309", 10);
            if (list != null) {
                foreach (var info in list) {
                    Response.Write(info.ShortMessage + " " + info.Count);
                }
            }
            //loggingService.LogAsync("院校", Domain.Logging.ActionLogOperateType.Insert, "添加院校成功", "海鹏", "1");

            //Response.Write("success");
        }
    }
}