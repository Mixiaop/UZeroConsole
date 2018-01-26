using System;
using U;
using U.Utilities.Web;
using UZeroConsole.Domain.Logging;
using UZeroConsole.Services.Logging;
namespace UZeroConsole.Web.UZeroSOA.Logging
{
    public partial class Visit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var appService = UPrimeEngine.Instance.Resolve<ILogAppService>();
            var logService = UPrimeEngine.Instance.Resolve<IActionLogService>();


            string appKey = WebHelper.GetString("appKey");                 //应用密钥
            string ipAddress = WebHelper.GetIP();                         //IP地址
            string url = WebHelper.GetThisPageUrl(true);                    //路径
            string userAgent = WebHelper.GetUserAgent();
            string operatorId = WebHelper.GetIP();
            string remark = WebHelper.GetFormString("remark");             //备注（HttpException）

            var app = appService.Get(appKey);

            if (app != null)
            {
                ActionLog log = new ActionLog();
                log.AppId = app.Id;
                log.ModuleName = "";
                log.OperateTypeId = 0;
                log.ShortMessage = "";
                log.FullMessage = "";
                log.IpAddress = ipAddress;
                log.Url = url;
                log.UserAgent = userAgent;
                log.Operator = "";
                log.OperatorId = operatorId;
                log.Remark = remark;

                logService.Insert(log);
            }
        }
    }
}