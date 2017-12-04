using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Linq;
using U;
using U.Utilities.Web;
using UZeroConsole.Services;
using UZeroConsole.Services.Sso;

namespace UZeroConsole.Web.UZero.Sso
{
    /// <summary>
    /// Sso
    /// </summary>
    public partial class AdminCreate : AuthPageBase
    {
        IAdminService _adminService = UPrimeEngine.Instance.Resolve<IAdminService>();
        IRoleService _roleService = UPrimeEngine.Instance.Resolve<IRoleService>();
        IAppService _appService = UPrimeEngine.Instance.Resolve<IAppService>();

        protected void Page_Load(object sender, EventArgs e)
        {
            btnSave.Click += btnSave_Click;
            InitRoles();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            #region 添加管理员
            try
            {
                string username = tbUsername.Text.Trim();
                string password = tbPassword.Text.Trim();
                string name = tbName.Text.Trim();
                string remark = tbRemark.Text.Trim();
                string[] roleIds = hfRoleId.Value.Trim().Split(',');

                if (string.IsNullOrEmpty(username))
                {
                    ltlMessage.Text = AlertError("用户名不能为空");
                    return;
                }

                if (string.IsNullOrEmpty(password))
                {
                    ltlMessage.Text = AlertError("密码不能为空");
                    return;
                }

                if (string.IsNullOrEmpty(name))
                {
                    ltlMessage.Text = AlertError("姓名（昵称）不能为空");
                    return;
                }
                List<int> roles = new List<int>();
                if (roleIds != null && roleIds.Length > 0) {
                    foreach (var rid in roleIds) {
                        if (rid.IsNotNullOrEmpty())
                        {
                            roles.Add(rid.ToInt());
                        }
                    }
                }
                _adminService.Create(username, password, name, roles, remark);
                LogInsert("添加了管理员", username);
                ltlMessage.Text = AlertSuccess("添加成功");
                this.RedirectByTime(WebHelper.GetUrl(), 1000);
            }
            catch (Exception ex)
            {
                LogError(ex.Message, ex);
                ltlMessage.Text = AlertError(ex.Message);
                return;
            }
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
                    foreach (var role in roleList.Where(x=>x.SsoAppId == app.Id).ToList())
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
}