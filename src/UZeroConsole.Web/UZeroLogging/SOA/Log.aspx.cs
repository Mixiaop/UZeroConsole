using System;
using Newtonsoft.Json;
using U;
using U.Utilities.Web;
using U.WebApi.Models;
using UZeroConsole.Domain.Logging;
using UZeroConsole.Services.Logging;

namespace UZeroConsole.Web.UZeroLogging.SOA
{
    /// <summary>
    /// SOA接口记录操作日志
    /// 【POST请求】
    /// </summary>
    public partial class Log : System.Web.UI.Page
    {
        ILogAppService _appService = UPrimeEngine.Instance.Resolve<ILogAppService>();
        IActionLogService _logService = UPrimeEngine.Instance.Resolve<IActionLogService>();

        protected void Page_Load(object sender, EventArgs e)
        {
            string appKey = WebHelper.GetString("appKey");                 //应用密钥
            string moduleName = WebHelper.GetFormString("moduleName");     //模块名称
            int typeId = WebHelper.GetFormInt("typeId", 0);                //操作类型CURD
            string shortMessage = WebHelper.GetFormString("shortMessage"); //短消息
            string fullMessage = WebHelper.GetFormString("fullMessage");   //详细消息
            string ipAddress = WebHelper.GetFormString("ipAddress");       //IP地址
            string url = WebHelper.GetFormString("url");                   //路径
            string userAgent = WebHelper.GetFormString("userAgent");       //user agent
            string operatorName = WebHelper.GetFormString("operatorName"); //操作者
            string operatorId = WebHelper.GetFormString("operatorId");     //操作者标识
            string remark = WebHelper.GetFormString("remark");             //备注（HttpException）

            UResponseMessage res = new UResponseMessage();

            var app = _appService.Get(appKey);

            if (app != null)
            {
                ActionLog log = new ActionLog();
                log.AppId = app.Id;
                log.ModuleName = moduleName;
                log.OperateTypeId = typeId;
                log.ShortMessage = shortMessage;
                log.FullMessage = fullMessage;
                log.IpAddress = ipAddress;
                log.Url = url;
                log.UserAgent = userAgent;
                log.Operator = operatorName;
                log.OperatorId = operatorId;
                log.Remark = remark;

                _logService.Insert(log);
                res.Code = UResponseStatusCode.Ok;
            }
            else
            {
                res.Code = UResponseStatusCode.Error;
                res.Message = "appKey error";
            }

            Response.Write(JsonConvert.SerializeObject(res));
        }
    }
}