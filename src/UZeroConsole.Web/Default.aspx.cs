using System;
using System.Collections.Generic;
using System.Linq;
using AjaxPro;
using U;
using UZeroConsole.Domain;
using UZeroConsole.Configuration;
using UZeroConsole.Services;
using UZeroConsole.Services.Dto;

namespace UZeroConsole.Web
{
    public partial class Default : AuthPageBase
    {
        public IList<PermissionDto> Permissions = new List<PermissionDto>();
        protected ConsoleSettings ConsoleSettings = UPrimeEngine.Instance.Resolve<ConsoleSettings>();
        protected void Page_Load(object sender, EventArgs e)
        {
         
            Utility.RegisterTypeForAjax(typeof(UZeroConsole.Web.AjaxServices.UZero.AdminService));

            IPermissionsService permissionService = UPrimeEngine.Instance.Resolve<IPermissionsService>();
            IRoleService roleService = UPrimeEngine.Instance.Resolve<IRoleService>();
            if (Admin.AdminUserName == CurrentAdmin.Username)
            {
                Permissions = permissionService.GetAll().OrderBy(x => x.Order).ToList();
            }
            else
            {
                var rolePermissions = roleService.GetPermissions(CurrentAdmin.RoleId);
                if (rolePermissions != null)
                {
                    foreach (var rp in rolePermissions.Where(x => x.Permission != null).OrderBy(x => x.Permission.Order))
                    {
                        Permissions.Add(rp.Permission);
                    }
                }
            }
        }
    }
}