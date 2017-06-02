using System;
using AjaxPro;
using U;
using UZeroConsole.Services;

namespace UZeroConsole.Web.UZero
{
    public partial class PermissionList : System.Web.UI.Page
    {
        protected IPermissionsService permissionService = UPrimeEngine.Instance.Resolve<IPermissionsService>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(UZeroConsole.Web.AjaxServices.UZero.PermissionService));
        }
    }
}