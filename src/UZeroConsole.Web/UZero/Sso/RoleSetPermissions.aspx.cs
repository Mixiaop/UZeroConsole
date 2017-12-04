using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using U;
using U.Utilities.Web;
using UZeroConsole.Services;
using UZeroConsole.Services.Dto;

namespace UZeroConsole.Web.UZero.Sso
{
    /// <summary>
    /// Sso
    /// </summary>
    public partial class RoleSetPermissions : AuthPageBase
    {
        IPermissionsService _permissionService = UPrimeEngine.Instance.Resolve<IPermissionsService>();
        IRoleService _roleService = UPrimeEngine.Instance.Resolve<IRoleService>();

        protected RoleSetPermissionsModel Model = new RoleSetPermissionsModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSave.Click += btnSave_Click;
            if (!Settings.IsSsoOpend)
            {
                Response.Redirect("/UZero/RoleSetPermissions.aspx");
            }

            if (Model.GetRoleId == 0)
                Response.Redirect("RoleList.aspx");

            Model.Role = _roleService.Get(Model.GetRoleId);

            txtRoleName.Text = Model.Role.Name;

            InitPermissions();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            #region 保存

            if (!string.IsNullOrEmpty(hfPermissionIds.Value))
            {
                _roleService.DeleteAllPermissions(Model.Role.Id);

                string[] permissionIds = hfPermissionIds.Value.Split(',');
                foreach (string pid in permissionIds)
                {
                    RolePermissionDto info = new RolePermissionDto();
                    info.RoleId = Model.Role.Id;
                    info.PermissionId = pid.ToInt();
                    _roleService.AddPermission(info);
                }

                ltlSuccessMessage.Text = this.AlertSuccess("权限设置成功");
                this.RedirectByTime("RoleList.aspx", 1000);
                InitPermissions();
            }
            #endregion
        }

        void InitPermissions()
        {
            var nbsp = HttpUtility.HtmlDecode("&nbsp;");
            phPermissions.Controls.Clear();

            var grantedPermissions = _roleService.GetPermissions(Model.Role.Id);
            IList<PermissionDto> allPermissions = new List<PermissionDto>();
            if (Model.Role.SsoApp != null && Model.Role.SsoApp.IsSystem)
            {
                allPermissions = _permissionService.GetAllBySystem();
            }
            else
            {
                allPermissions = _permissionService.GetAll(Model.Role.SsoAppId);
            }
            var level1List = allPermissions.Where(x => x.Level == 1);
            if (level1List != null)
            {
                #region Level1
                foreach (var level1 in level1List)
                {
                    HtmlGenericControl divLevel1 = new HtmlGenericControl("div");
                    divLevel1.Attributes["class"] = "checkbox";

                    HtmlGenericControl lblLevel1 = new HtmlGenericControl("label");
                    HtmlGenericControl cbLevel1 = new HtmlGenericControl("input");
                    cbLevel1.Attributes["type"] = "checkbox";
                    cbLevel1.Attributes["value"] = level1.Id.ToString();
                    cbLevel1.Attributes["data-level"] = "1";
                    cbLevel1.Attributes["id"] = "permission-" + level1.Id;
                    if (grantedPermissions.Where(x => x.PermissionId == level1.Id).Count() > 0)
                    {
                        cbLevel1.Attributes["checked"] = "checked";
                    }

                    Literal ltlLevel1 = new Literal();
                    ltlLevel1 = new Literal();
                    ltlLevel1.Text = " " + level1.Name;

                    lblLevel1.Controls.Add(cbLevel1);
                    lblLevel1.Controls.Add(ltlLevel1);
                    divLevel1.Controls.Add(lblLevel1);
                    phPermissions.Controls.Add(divLevel1);

                    #region Level2
                    var level2List = allPermissions.Where(x => x.ParentId == level1.Id);
                    if (level2List != null)
                    {
                        foreach (var level2 in level2List)
                        {
                            HtmlGenericControl divLevel2 = new HtmlGenericControl("div");
                            divLevel2.Attributes["class"] = "checkbox";
                            divLevel2.Attributes["style"] = "padding-left:20px";

                            HtmlGenericControl lblLevel2 = new HtmlGenericControl("label");
                            HtmlGenericControl cbLevel2 = new HtmlGenericControl("input");
                            cbLevel2.Attributes["type"] = "checkbox";
                            cbLevel2.Attributes["value"] = level2.Id.ToString();
                            cbLevel2.Attributes["parentId"] = level1.Id.ToString();
                            cbLevel2.Attributes["data-level"] = "2";
                            cbLevel2.Attributes["id"] = "permission-" + level2.Id;
                            if (grantedPermissions.Where(x => x.PermissionId == level2.Id).Count() > 0)
                            {
                                cbLevel2.Attributes["checked"] = "checked";
                            }

                            Literal ltlLevel2 = new Literal();
                            ltlLevel2 = new Literal();
                            ltlLevel2.Text = " " + level2.Name;

                            lblLevel2.Controls.Add(cbLevel2);
                            lblLevel2.Controls.Add(ltlLevel2);
                            divLevel2.Controls.Add(lblLevel2);
                            phPermissions.Controls.Add(divLevel2);

                            #region Level3
                            var level3List = allPermissions.Where(x => x.ParentId == level2.Id);
                            if (level3List != null)
                            {
                                foreach (var level3 in level3List)
                                {
                                    HtmlGenericControl divLevel3 = new HtmlGenericControl("div");
                                    divLevel3.Attributes["class"] = "checkbox";
                                    divLevel3.Attributes["style"] = "padding-left:40px";

                                    HtmlGenericControl lblLevel3 = new HtmlGenericControl("label");
                                    HtmlGenericControl cbLevel3 = new HtmlGenericControl("input");
                                    cbLevel3.Attributes["type"] = "checkbox";
                                    cbLevel3.Attributes["value"] = level3.Id.ToString();
                                    cbLevel3.Attributes["parentId"] = level2.Id.ToString();
                                    cbLevel3.Attributes["rootId"] = level1.Id.ToString();
                                    cbLevel3.Attributes["data-level"] = "3";
                                    cbLevel3.Attributes["id"] = "permission-" + level3.Id;

                                    if (grantedPermissions.Where(x => x.PermissionId == level3.Id).Count() > 0)
                                    {
                                        cbLevel3.Attributes["checked"] = "checked";
                                    }

                                    Literal ltlLevel3 = new Literal();
                                    ltlLevel3 = new Literal();
                                    ltlLevel3.Text = " " + level3.Name;

                                    lblLevel3.Controls.Add(cbLevel3);
                                    lblLevel3.Controls.Add(ltlLevel3);
                                    divLevel3.Controls.Add(lblLevel3);
                                    phPermissions.Controls.Add(divLevel3);
                                }
                            }
                            #endregion
                        }
                    }
                    #endregion
                }
                #endregion
            }
        }
    }

    public class RoleSetPermissionsModel
    {
        public int GetRoleId { get { return WebHelper.GetInt("roleId", 0); } }

        public RoleDto Role { get; set; }
    }
}