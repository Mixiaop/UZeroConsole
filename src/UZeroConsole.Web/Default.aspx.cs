using System;
using System.Collections.Generic;
using System.Linq;
using AjaxPro;
using U;
using U.AutoMapper;
using UZeroConsole.Domain;
using UZeroConsole.Domain.Sso;
using UZeroConsole.Services;
using UZeroConsole.Services.Dto;
using UZeroConsole.Services.Sso;
using UZeroConsole.Services.Sso.Dto;

namespace UZeroConsole.Web
{
    public partial class Default : AuthPageBase
    {
        IPermissionsService _permissionService = UPrimeEngine.Instance.Resolve<IPermissionsService>();
        IRoleService _roleService = UPrimeEngine.Instance.Resolve<IRoleService>();
        IAppService _appService = UPrimeEngine.Instance.Resolve<IAppService>();

        public DefaultModel Model = new DefaultModel();
        protected void Page_Load(object sender, EventArgs e)
        {

            Utility.RegisterTypeForAjax(typeof(UZeroConsole.Web.AjaxServices.UZero.AdminService));
            Model.IsOpendSso = this.Settings.IsSsoOpend;
            if (Model.IsOpendSso)
            {
                #region Sso
                Model.CurrentApp = _appService.GetByKey(this.Settings.SsoAppKey);
                if (Model.CurrentApp != null)
                {
                    if (CurrentAdmin.IsSuperAdmin())
                    {
                        Model.Permissions = _permissionService.GetAll(Model.CurrentApp.Id);
                        var apps = _appService.GetAll(false);
                        if (apps != null) {
                            foreach (var appInfo in apps) {
                                Model.Apps.Add(appInfo.MapTo<AppDto>());
                            }
                        }
                    }
                    else {
                        var rolePermissions = _roleService.GetPermissions(CurrentAdmin.RoleIds);
                        if (rolePermissions != null)
                        {
                            foreach (var rp in rolePermissions.Where(x => x.Permission != null).OrderBy(x => x.Permission.Order))
                            {
                                if (rp.Role.SsoAppId == Model.CurrentApp.Id)
                                    Model.Permissions.Add(rp.Permission);

                                if (rp.Role.SsoApp != null && !Model.Apps.Contains(rp.Role.SsoApp)) {
                                    Model.Apps.Add(rp.Role.SsoApp);
                                }
                            }
                        }
                    }
                }
                #endregion
            }
            else
            {
                #region Single
                if (Admin.AdminUserName == CurrentAdmin.Username)
                {
                    Model.Permissions = _permissionService.GetAll().OrderBy(x => x.Order).ToList();
                }
                else
                {
                    var rolePermissions = _roleService.GetPermissions(CurrentAdmin.RoleId);
                    if (rolePermissions != null)
                    {
                        foreach (var rp in rolePermissions.Where(x => x.Permission != null).OrderBy(x => x.Permission.Order))
                        {
                            Model.Permissions.Add(rp.Permission);
                        }
                    }
                }
                #endregion
            }
        }
    }

    public class DefaultModel
    {
        public DefaultModel() {
            Permissions = new List<PermissionDto>();
            Apps = new List<AppDto>();
        }

        public bool IsOpendSso { get; set; }

        public IList<PermissionDto> Permissions { get; set; }

        public App CurrentApp { get; set; }

        /// <summary>
        /// 有权限的所有应用
        /// </summary>
        public IList<AppDto> Apps { get; set; }
    }
}