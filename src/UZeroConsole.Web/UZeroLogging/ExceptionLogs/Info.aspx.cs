using System;
using U;
using U.Utilities.Web;
using UZeroConsole.Domain.Logging;
using UZeroConsole.Services.Logging;

namespace UZeroConsole.Web.UZeroLogging.ExceptionLogs
{
    public partial class Info : AuthPageBase
    {
        ILogAppService _appService = UPrimeEngine.Instance.Resolve<ILogAppService>();
        IExceptionLogService _logService = UPrimeEngine.Instance.Resolve<IExceptionLogService>();

        protected InfoModel Model = new InfoModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            Model.Log = _logService.Get(Model.GetLogId);
            if (Model.Log == null)
                Response.Redirect("../LogApps/List.aspx");

        }
    }

    public class InfoModel
    {
        public int GetLogId { get { return WebHelper.GetInt("logId", 0); } }

        public ExceptionLog Log { get; set; }
    }
}