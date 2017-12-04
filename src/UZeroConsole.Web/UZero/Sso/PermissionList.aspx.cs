using System;
using System.Collections.Generic;
using AjaxPro;
using U;
using U.Utilities.Web;
using UZeroConsole.Domain.Sso;
using UZeroConsole.Services;
using UZeroConsole.Services.Dto;
using UZeroConsole.Services.Sso;

namespace UZeroConsole.Web.UZero.Sso
{
    public partial class PermissionList : AuthPageBase
    {
        IPermissionsService _permissionService = UPrimeEngine.Instance.Resolve<IPermissionsService>();
        IAppService _appService = UPrimeEngine.Instance.Resolve<IAppService>();

        protected PermissionListModel Model = new PermissionListModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(UZeroConsole.Web.AjaxServices.UZero.PermissionService));
            if (!Settings.IsSsoOpend)
            {
                Response.Redirect("/UZero/PermissionList.aspx");
            }

            if (!IsPostBack)
            {
                Model.Apps = _appService.GetAll();
                int appId = Model.GetAppId;
                if (appId == 0 && Model.Apps != null && Model.Apps.Count > 0)
                {
                    appId = Model.Apps[0].Id;
                }

                Model.Permissions = _permissionService.GetAll(appId, true);

            }
        }
    }

    public class PermissionListModel
    {
        public int GetAppId { get { return WebHelper.GetInt("appId", 0); } }

        public IList<App> Apps { get; set; }

        public IList<PermissionDto> Permissions { get; set; }
    }
}