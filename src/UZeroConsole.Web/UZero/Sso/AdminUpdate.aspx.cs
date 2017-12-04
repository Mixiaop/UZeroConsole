using System;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using U;
using U.Utilities.Web;
using UZeroConsole.Domain;
using UZeroConsole.Services;
using UZeroConsole.Services.Dto;
using UZeroConsole.Services.Sso;

namespace UZeroConsole.Web.UZero.Sso
{
    /// <summary>
    /// Sso
    /// </summary>
    public partial class AdminUpdate : AuthPageBase
    {
        IAdminService _adminService = UPrimeEngine.Instance.Resolve<IAdminService>();
        IRoleService _roleService = UPrimeEngine.Instance.Resolve<IRoleService>();
        IAppService _appService = UPrimeEngine.Instance.Resolve<IAppService>();


        protected AdminUpdateModel Model = new AdminUpdateModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSave.Click += btnSave_Click;
            Model.Admin = _adminService.GetEntity(WebHelper.GetInt("adminId", 0));
            if (Model.Admin == null)
                Response.Redirect("AdminList.aspx");

            if (!IsPostBack)
            {
                tbUsername.Text = Model.Admin.Username;
                tbName.Text = Model.Admin.Name;
                tbRemark.Text = Model.Admin.Remark;

                if (Model.Admin.Roles != null)
                {
                    foreach (var role in Model.Admin.Roles)
                    {
                        hfRoleId.Value += role.Id + ",";
                    }
                    if (hfRoleId.Value.IsNotNullOrEmpty())
                        hfRoleId.Value = hfRoleId.Value.TrimEnd(",");
                }

            }

            InitRoles();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            #region 编辑管理员
            string name = tbName.Text.Trim();
            string remark = tbRemark.Text.Trim();
            string[] roleIds = hfRoleId.Value.Trim().Split(',');

            if (string.IsNullOrEmpty(name))
            {
                ltlMessage.Text = AlertError("姓名（昵称）不能为空");
                return;
            }

            List<int> roles = new List<int>();
            if (roleIds != null && roleIds.Length > 0)
            {
                foreach (var rid in roleIds)
                {
                    if (rid.IsNotNullOrEmpty())
                    {
                        roles.Add(rid.ToInt());
                    }
                }
            }

            _adminService.Update(Model.Admin.Id, name, roles, remark);
            LogUpdate("修改了管理员", name);
            ltlMessage.Text = AlertSuccess("编辑成功");
            this.RedirectByTime("AdminList.aspx", 1000);
            #endregion
        }

        void InitRoles()
        {
            var appList = _appService.GetAll(false);
            var roleList = _roleService.GetAll();
            if (appList != null)
            {
                foreach (var app in appList)
                {
                    HtmlGenericControl title = new HtmlGenericControl("div");
                    title.InnerText = app.ToString();
                    phRoles.Controls.Add(title);
                    foreach (var role in roleList.Where(x => x.SsoAppId == app.Id).ToList())
                    {
                        HtmlGenericControl div = new HtmlGenericControl("div");
                        div.Attributes["class"] = "radio";
                        div.Attributes["style"] = "padding-bottom:10px;";
                        HtmlGenericControl label = new HtmlGenericControl("label");
                        HtmlGenericControl checkbox = new HtmlGenericControl("input");


                        checkbox.Attributes["type"] = "checkbox";
                        checkbox.ID = "role-" + role.Id;
                        checkbox.Attributes["name"] = "role";
                        checkbox.Attributes["value"] = role.Id.ToString();
                        if (Model.Admin.Roles != null && Model.Admin.RoleIds.Contains(role.Id))
                        {
                            checkbox.Attributes["checked"] = "checked";
                        }

                        Literal name = new Literal();
                        name.Text = role.Name;

                        label.Controls.Add(checkbox);
                        label.Controls.Add(name);
                        div.Controls.Add(label);
                        phRoles.Controls.Add(div);
                    }
                }
            }
        }
    }

    public class AdminUpdateModel
    {
        public Admin Admin { get; set; }
    }
}