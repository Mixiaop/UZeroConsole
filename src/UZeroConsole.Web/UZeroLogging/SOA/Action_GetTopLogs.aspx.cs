using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using U;
using U.Utilities.Web;
using U.WebApi.Models;
using UZeroConsole.Services.Logging;
using UZeroConsole.Services.Logging.Dto;

namespace UZeroConsole.Web.UZeroLogging.SOA
{
    public partial class Action_GetTopLogs : System.Web.UI.Page
    {
        ILogAppService _appService = UPrimeEngine.Instance.Resolve<ILogAppService>();
        IActionLogService _logService = UPrimeEngine.Instance.Resolve<IActionLogService>();

        protected void Page_Load(object sender, EventArgs e)
        {
            string appKey = WebHelper.GetString("appKey");                 //应用密钥
            string operatorId = WebHelper.GetFormString("operatorId");     //操作者标识
            int topCount = WebHelper.GetFormInt("topCount", 10);         

            UResponseMessage<IList<ActionLogTopDto>> res = new UResponseMessage<IList<ActionLogTopDto>>();

            var app = _appService.Get(appKey);

            if (app != null)
            {
                res.Results = _logService.GetTopLogs(app.Id, operatorId, topCount);
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