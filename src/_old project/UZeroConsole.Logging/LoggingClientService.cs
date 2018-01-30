using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using U.WebApi.Models;
using U.Utilities.Web;
using U.Utilities.Net;
using UZeroConsole.Configuration;
using UZeroConsole.Domain.Logging;
using UZeroConsole.Services.Logging.Dto;

namespace UZeroConsole.Logging
{
    public class LoggingClientService : ILoggingClientService
    {
        private readonly LoggingSettings _settings;
        public const string SOA_Exception = "/UZeroLogging/SOA/Exception.aspx";
        public const string SOA_Log = "/UZeroLogging/SOA/Log.aspx";
        public const string SOA_ActionGetTopLogs = "/UZeroLogging/SOA/Action_GetTopLogs.aspx";
        public LoggingClientService(LoggingSettings settings)
        {
            _settings = settings;
        }

        public void HandleException(Exception ex, string appKey = "")
        {
            if (appKey.IsNullOrEmpty())
                appKey = _settings.DefaultKey;

            var log = CreateExceptionLog(ex);
            log.App.Key = appKey;
            HttpException httpException = ex as HttpException;
            if (httpException != null)
            {
                log.StatusCode = httpException.GetHttpCode().ToString();
                log.FullMessage += "[HtmlErrorMessage]：" + httpException.GetHtmlErrorMessage();
            }

            SendException(log);
        }

        public Task HandleExceptionAsync(Exception ex, string appKey = "")
        {
            if (appKey.IsNullOrEmpty())
                appKey = _settings.DefaultKey;

            var log = CreateExceptionLog(ex);
            log.App.Key = appKey;
            HttpException httpException = ex as HttpException;
            if (httpException != null)
            {
                log.StatusCode = httpException.GetHttpCode().ToString();
                log.FullMessage += "[HtmlErrorMessage]：" + httpException.GetHtmlErrorMessage();
            }
            SendException(log, true);
            return Task.FromResult(0);
        }

        public void Log(string moduleName = "", ActionLogOperateType operateType = ActionLogOperateType.None,
                 string shortMessage = "", string operatorName = "", string operatorId = "", string fullMessage = "", string remark = "", string appKey = "")
        {
            if (appKey.IsNullOrEmpty())
                appKey = _settings.DefaultKey;

            var log = CreateActionLog();
            log.App.Key = appKey;
            log.ModuleName = moduleName;
            log.OperateType = operateType;
            log.ShortMessage = shortMessage;
            log.FullMessage = fullMessage;
            log.Operator = operatorName;
            log.OperatorId = operatorId;
            log.Remark = remark;

            SendActionLog(log);
        }

        public Task LogAsync(string moduleName = "", ActionLogOperateType operateType = ActionLogOperateType.None,
                 string shortMessage = "", string operatorName = "", string operatorId = "", string fullMessage = "", string remark = "", string appKey = "")
        {
            if (appKey.IsNullOrEmpty())
                appKey = _settings.DefaultKey;

            var log = CreateActionLog();
            log.App.Key = appKey;
            log.ModuleName = moduleName;
            log.OperateType = operateType;
            log.ShortMessage = shortMessage;
            log.FullMessage = fullMessage;
            log.Operator = operatorName;
            log.OperatorId = operatorId;
            log.Remark = remark;

            SendActionLog(log, true);
            return Task.FromResult(0);
        }

        public IList<ActionLogTopDto> GetActionTopLogs(string appKey, string operatorId, int topCount = 10) {
            var url = _settings.SOAHost.TrimEnd("/") + SOA_ActionGetTopLogs;
            Dictionary<string, string> formData = new Dictionary<string, string>();
            formData.Add("appKey", appKey);
            formData.Add("operatorId", operatorId);
            formData.Add("topCount", topCount.ToString());

            var res = WebRequestHelper.HttpPost(url, formData);

            var json = JsonConvert.DeserializeObject<UResponseMessage<IList<ActionLogTopDto>>>(res);
            if (json != null && json.IsSuccess())
            {
                return json.Results;
            }
            else
                return new List<ActionLogTopDto>();
        }

        #region Utilities
        /// <summary>
        /// 发送异常到SOA接口
        /// </summary>
        /// <param name="log"></param>
        /// <param name="isAsync"></param>
        private void SendException(ExceptionLog log, bool isAsync = false)
        {
            var url = _settings.SOAHost.TrimEnd("/") + SOA_Exception;
            Dictionary<string, string> formData = new Dictionary<string, string>();
            formData.Add("appKey", log.App.Key);
            formData.Add("machineName", log.MachineName);
            formData.Add("type", log.Type);
            formData.Add("shortMessage", log.ShortMessage);
            formData.Add("fullMessage", log.FullMessage);
            formData.Add("ipAddress", log.IpAddress);
            formData.Add("host", log.Host);
            formData.Add("url", log.Url);
            formData.Add("userAgent", log.UserAgent);
            formData.Add("httpMethod", log.HttpMethod);
            formData.Add("statusCode", log.StatusCode);

            //try
            //{
            WebRequestHelper.HttpPost(url, formData);
            //}
            //catch (Exception ex) {
            //var b = 1;
            //}
            //if (isAsync)
            //{
            //    WebRequestHelper.HttpPostAsync(url, formData);
            //}
            //else
            //{
            //    WebRequestHelper.HttpPost(url, formData);
            //}
        }

        private void SendActionLog(ActionLog log, bool isAsync = false)
        {
            var url = _settings.SOAHost.TrimEnd("/") + SOA_Log;
            Dictionary<string, string> formData = new Dictionary<string, string>();
            formData.Add("appKey", log.App.Key);
            formData.Add("moduleName", log.ModuleName);
            formData.Add("typeId", log.OperateTypeId.ToString());
            formData.Add("shortMessage", log.ShortMessage);
            formData.Add("fullMessage", log.FullMessage);
            formData.Add("ipAddress", log.IpAddress);
            formData.Add("url", log.Url);
            formData.Add("userAgent", log.UserAgent);
            formData.Add("operatorName", log.Operator);
            formData.Add("operatorId", log.OperatorId);
            formData.Add("remark", log.Remark);
            WebRequestHelper.HttpPost(url, formData);
            //if (isAsync)
            //{
            //    WebRequestHelper.HttpPostAsync(url, formData);
            //}
            //else
            //{
            //    WebRequestHelper.HttpPost(url, formData);
            //}
        }

        /// <summary>
        /// 创建一个普通异常实体
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private ExceptionLog CreateExceptionLog(Exception ex)
        {
            ExceptionLog log = new ExceptionLog();
            log.Type = ex.Source;
            log.ShortMessage = ex.Message;
            log.FullMessage = ex.ToString();
            if (ex.InnerException != null) {
                log.ShortMessage += string.Format("【{0}】", ex.InnerException.Message);
            }
            if (HttpContext.Current != null)
            {
                log.MachineName = WebHelper.GetSystemInfo(log.UserAgent);
                log.IpAddress = WebHelper.GetIP();
                log.UserAgent = WebHelper.GetUserAgent();
                log.Host = WebHelper.GetHost();
                log.Url = WebHelper.GetUrl();
                log.HttpMethod = HttpContext.Current.Request.HttpMethod.ToString();
            }
            log.App = new LogApp();
            return log;
        }

        private ActionLog CreateActionLog()
        {
            ActionLog log = new ActionLog();
            if (HttpContext.Current != null)
            {
                log.IpAddress = WebHelper.GetIP();
                log.UserAgent = WebHelper.GetUserAgent();
                log.Url = WebHelper.GetUrl();
            }
            log.App = new LogApp();
            return log;
        }
        #endregion
    }
}
