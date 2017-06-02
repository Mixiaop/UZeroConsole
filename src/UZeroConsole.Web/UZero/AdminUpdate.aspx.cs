using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using U;
using U.Utilities.Web;
using UZeroConsole.Services;
using UZeroConsole.Services.Dto;

namespace UZeroConsole.Web.UZero
{
    public partial class AdminUpdate : AuthPageBase
    {
        IAdminService adminService = UPrimeEngine.Instance.Resolve<IAdminService>();
        IRoleService roleService = UPrimeEngine.Instance.Resolve<IRoleService>();
        AdminDto admin;
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSave.Click += btnSave_Click;
            admin = adminService.Get(WebHelper.GetInt("adminId", 0));
            if (admin == null)
                Response.Redirect("AdminList.aspx");

            if (!IsPostBack)
            {
                tbUsername.Text = admin.Username;
                tbName.Text = admin.Name;
                tbRemark.Text = admin.Remark;
                hfRoleId.Value = admin.RoleId.ToString();
            }

            InitRoles();
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            #region 编辑管理员
            string name = tbName.Text.Trim();
            string remark = tbRemark.Text.Trim();
            int roleId = hfRoleId.Value.Trim().ToInt();

            if (string.IsNullOrEmpty(name))
            {
                ltlMessage.Text = AlertError("姓名（昵称）不能为空");
                return;
            }

            adminService.Update(admin.Id, name, roleId, remark);
            LogUpdate("修改了管理员", name);
            ltlMessage.Text = AlertSuccess("编辑成功");
            this.RedirectByTime("AdminList.aspx", 1000);
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
                if (admin.RoleId == role.Id)
                {
                    radio.Attributes["checked"] = "checked";
                }

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