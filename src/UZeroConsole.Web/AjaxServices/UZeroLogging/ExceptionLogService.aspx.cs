using System;
using AjaxPro;
using U;
using UZeroConsole.Services.Logging;

namespace UZeroConsole.Web.AjaxServices.UZeroLogging
{
    [AjaxNamespace("ExceptionLogService")]
    public partial class ExceptionLogService : System.Web.UI.Page
    {
        IExceptionLogService _logService = UPrimeEngine.Instance.Resolve<IExceptionLogService>();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [AjaxMethod]
        public void ClearAll(int appId)
        {
            _logService.ClearAll(appId);
        }
    }
}