using System;
using System.Web.UI.WebControls;
using U;
using U.Utilities.Web;
using UZeroConsole.Services;
using UZeroConsole.Services.Dto;

namespace UZeroConsole.Web.UZero
{
    public partial class AdminList : AuthPageBase
    {
        IRoleService roleService = UPrimeEngine.Instance.Resolve<IRoleService>();
        IAdminService adminService = UPrimeEngine.Instance.Resolve<IAdminService>();
        protected string PagerHtml;
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSearch.Click += btnSearch_Click;
            if (Settings.IsSsoOpend && Settings.IsSsoServer)
            {
                Response.Redirect("/UZero/Sso/AdminList.aspx");
            }

            if (!IsPostBack)
            {
                var roles = roleService.GetAll();
                ddlRole.DataSource = roles;
                ddlRole.DataValueField = "Id";
                ddlRole.DataTextField = "Name";
                ddlRole.DataBind();
                ddlRole.Items.Insert(0, new ListItem("全部角色", "-1"));

                ddlRole.SelectedValue = WebHelper.GetString("role");
                tbSearchKeywords.Text = WebHelper.GetString("wd");
                BindPageDatas(GetUrlParam(), true);
            }
        }

        protected void btnResetPassword(object sender, EventArgs e)
        {
            #region 重置密码
            LinkButton lb = (LinkButton)sender;
            int adminId = Convert.ToInt32(lb.CommandArgument);
            if (adminId > 0)
            {
                var rand = new Random();
                string newPassword = rand.Next(9).ToString() + rand.Next(9).ToString() + rand.Next(9).ToString() + rand.Next(9).ToString() + rand.Next(9).ToString() + rand.Next(9).ToString();

                adminService.ResetPassword(adminId, newPassword);
                BindPageDatas(GetUrlParam(), true);
                ltlMessage.Text = AlertSuccess(string.Format("密码重置成功 [新密码：{0}]，请登录后修改！", newPassword));
            }
            #endregion
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            #region 删除
            try
            {
                LinkButton lb = (LinkButton)sender;
                int adminId = Convert.ToInt32(lb.CommandArgument);
                if (adminId > 0)
                {
                    adminService.Delete(adminId);
                    LogDelete("删除了管理员,该Id为", adminId.ToString());
                    BindPageDatas(GetUrlParam(), true);
                    ltlMessage.Text = AlertSuccess("删除成功", "", 3000);
                }
            }
            catch (Exception ex)
            {
                LogError(ex.Message, ex);
                ltlMessage.Text = AlertError(ex.Message);
            }
            #endregion
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            #region 搜索
            BindPageDatas(GetUrlParam(), false);
            #endregion
        }

        #region BindPageDatas
        private string GetUrlParam()
        {
            string cdi = "";
            if (!String.IsNullOrEmpty(tbSearchKeywords.Text.Trim()))
            {
                cdi += "wd=" + tbSearchKeywords.Text.Trim();
            }
            if (ddlRole.SelectedValue != "-1")
            {
                if (cdi != "")
                    cdi += "&";

                cdi += "role=" + ddlRole.SelectedValue;
            }
            if (WebHelper.GetString("page") != "")
            {
                if (cdi != "")
                    cdi += "&";
                cdi += "page=" + WebHelper.GetString("page");
            }
            return cdi;
        }

        void BindPageDatas(string url, bool pageInit)
        {
            PagingInfo pageInfo = new PagingInfo();
            pageInfo.PageIndex = pageInit ? WebHelper.GetInt("page", 1) : 1;
            pageInfo.PageSize = 10;
            pageInfo.Url = url == "" ? WebHelper.GetUrl() : "AdminList.aspx?" + url;

            SearchAdminInput input = new SearchAdminInput();
            input.PageIndex = pageInfo.PageIndex;
            input.PageSize = pageInfo.PageSize;
            input.Keywords = tbSearchKeywords.Text.Trim();
            input.RoleId = ddlRole.SelectedValue.ToInt();

            var results = adminService.Search(input);
            rptDatas.DataSource = results.Items;
            rptDatas.DataBind();

            pageInfo.TotalCount = results.TotalCount;
            PagerHtml = new Paginations(pageInfo).GetPaging();
        }
        #endregion

        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindPageDatas(GetUrlParam(), false);
        }
    }
}