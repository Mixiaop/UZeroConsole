using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using U;
using U.Utilities.Web;
using UZeroConsole.Services;
using UZeroConsole.Services.Dto;

namespace UZeroConsole.Web.UZero
{
    public partial class AdminCreate : AuthPageBase
    {
        IAdminService adminService = UPrimeEngine.Instance.Resolve<IAdminService>();
        IRoleService roleService = UPrimeEngine.Instance.Resolve<IRoleService>();
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
                int roleId = hfRoleId.Value.Trim().ToInt();

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

                adminService.Create(username, password, name, roleId, remark);
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
            var roleList = roleService.GetAll();
            foreach (var role in roleList)
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes["class"] = "radio";

                HtmlGenericControl label = new HtmlGenericControl("label");
                HtmlGenericControl radio = new HtmlGenericControl("input");

                radio.Attributes["type"] = "radio";
                radio.ID = "role-" + role.Id;
                radio.Attributes["name"] = "role";
                radio.Attributes["value"] = role.Id.ToString();

                Literal name = new Literal();
                name.Text = role.Name;

                label.Controls.Add(radio);
                label.Controls.Add(name);
                div.Controls.Add(label);
                phRoles.Controls.Add(div);
            }
        }
    }
}