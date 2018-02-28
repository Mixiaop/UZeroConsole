using Newtonsoft.Json;
using System;
using U;
using U.Application.Services.Dto;
using U.Utilities.Web;
using U.WebApi.Models;
using UZeroConsole.Services.Logging;
using UZeroConsole.Services.Logging.Dto;

namespace UZeroConsole.Web.UZeroSOA.Logging
{
    public partial class ActionLog_Search : System.Web.UI.Page
    {
        ILogAppService _appService = UPrimeEngine.Instance.Resolve<ILogAppService>();
        IActionLogService _logService = UPrimeEngine.Instance.Resolve<IActionLogService>();
        protected void Page_Load(object sender, EventArgs e)
        {
            string appKey = WebHelper.GetString("appKey");                 //应用密钥
            string operatorId = WebHelper.GetFormString("operatorId");     //操作者标识
            string moduleName = WebHelper.GetFormString("moduleName");     //模块名称
            int pageIndex = WebHelper.GetFormInt("pageIndex", 1);
            int pageSize = WebHelper.GetFormInt("pageSize", 10);

            UResponseMessage<PagedResultDto<ActionLogDto>> res = new UResponseMessage<PagedResultDto<ActionLogDto>>();

            var app = _appService.Get(appKey);

            if (app != null)
            {
                res.Results = _logService.Search(app.Id, moduleName, operatorId, "", null, null, pageIndex, pageSize);
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