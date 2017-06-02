using System;
using AjaxPro;
using U;
using UZeroConsole.Services;
using UZeroConsole.Services.Dto;

namespace UZeroConsole.Web.AjaxServices.UZero
{
     [AjaxNamespace("AdminService")]
    public partial class AdminService : System.Web.UI.Page
    {
        private readonly IAdminService _adminService = UPrimeEngine.Instance.Resolve<IAdminService>();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [AjaxMethod]
        public ChangePasswordOutput ChangePassword(ChangePasswordInput input)
        {
            return _adminService.ChangePassword(input);
        }
    }
}