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
    /// SOA接口记录异常日志
    /// 【POST请求】
    /// </summary>
    public partial class Exception : System.Web.UI.Page
    {
        ILogAppService _appService = UPrimeEngine.Instance.Resolve<ILogAppService>();
        IExceptionLogService _logService = UPrimeEngine.Instance.Resolve<IExceptionLogService>();

        protected void Page_Load(object sender, EventArgs e)
        {
            string appKey = WebHelper.GetString("appKey");                 //应用密钥
            string machineName = WebHelper.GetFormString("machineName");   //机器名
            string type = WebHelper.GetFormString("type");                  //异常类型
            string shortMessage = WebHelper.GetFormString("shortMessage"); //短消息
            string fullMessage = WebHelper.GetFormString("fullMessage");   //详细消息
            string ipAddress = WebHelper.GetFormString("ipAddress");       //IP地址
            string host = WebHelper.GetFormString("host");                 //应用端
            string url = WebHelper.GetFormString("url");                   //路径
            string userAgent = WebHelper.GetFormString("userAgent");       //user agent
            string httpMethod = WebHelper.GetFormString("httpMethod");     //GET OR POST
            string statusCode = WebHelper.GetFormString("statusCode");     //状态码（HttpException）

            UResponseMessage res = new UResponseMessage();

            var app = _appService.Get(appKey);

            if (app != null)
            {
                ExceptionLog log = new ExceptionLog();
                log.AppId = app.Id;
                log.MachineName = machineName;
                log.Type = type;
                log.ShortMessage = shortMessage;
                log.FullMessage = fullMessage;
                log.IpAddress = ipAddress;
                log.Host = host;
                log.Url = url;
                log.UserAgent = userAgent;
                log.HttpMethod = httpMethod;
                log.StatusCode = statusCode;
                _logService.Insert(log);
                res.Code = UResponseStatusCode.Ok;
            }
            else {
                res.Code = UResponseStatusCode.Error;
                res.Message = "appKey error";
            }

            Response.Write(JsonConvert.SerializeObject(res));
        }
    }
}