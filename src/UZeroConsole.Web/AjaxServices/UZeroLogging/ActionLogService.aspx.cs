using System;
using AjaxPro;
using U;
using UZeroConsole.Services.Logging;

namespace UZeroConsole.Web.AjaxServices.UZeroLogging
{
    [AjaxNamespace("ActionLogService")]
    public partial class ActionLogService : System.Web.UI.Page
    {
        IActionLogService _actionLogService = UPrimeEngine.Instance.Resolve<IActionLogService>();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [AjaxMethod]
        public void ClearAll(int appId)
        {
            _actionLogService.ClearAll(appId);
        }
    }
}