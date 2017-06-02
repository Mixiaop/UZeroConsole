using System;
using System.Collections.Generic;
using AjaxPro;
using U;
using UZeroConsole.Services;
using UZeroConsole.Services.Dto;

namespace UZeroConsole.Web.UZero
{
    public partial class RoleList : AuthPageBase
    {
        protected IRoleService roleService = UPrimeEngine.Instance.Resolve<IRoleService>();
        protected IList<RoleDto> roles;
        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(UZeroConsole.Web.AjaxServices.UZero.RoleService));
            roles = roleService.GetAll();
        }
    }
}