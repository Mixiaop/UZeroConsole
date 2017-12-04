using System;
using System.Collections.Generic;
using AjaxPro;
using U;
using U.Utilities.Web;
using UZeroConsole.Domain.Sso;
using UZeroConsole.Services;
using UZeroConsole.Services.Dto;
using UZeroConsole.Services.Sso;
using UZeroConsole.Services.Sso.Dto;

namespace UZeroConsole.Web.UZero.Sso
{
    /// <summary>
    /// Sso
    /// </summary>
    public partial class RoleList : AuthPageBase
    {
        IRoleService _roleService = UPrimeEngine.Instance.Resolve<IRoleService>();
        IAppService _appService = UPrimeEngine.Instance.Resolve<IAppService>();

        protected RoleListModel Model = new RoleListModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(UZeroConsole.Web.AjaxServices.UZero.RoleService));
            if (!Settings.IsSsoOpend)
            {
                Response.Redirect("/UZero/RoleList.aspx");
            }

            if (!IsPostBack)
            {
                Model.Apps = _appService.GetAll(false);
                var appId = Model.GetAppId;
                if (appId == 0 && Model.Apps != null && Model.Apps.Count > 0)
                {
                    appId = Model.Apps[0].Id;
                }
                
                Model.Roles = _roleService.GetAll(appId);
            }
        }
    }

    public class RoleListModel
    {
        public int GetAppId { get { return WebHelper.GetInt("appId", 0); } }

        public IList<RoleDto> Roles { get; set; }

        public IList<App> Apps { get; set; }
    }
}