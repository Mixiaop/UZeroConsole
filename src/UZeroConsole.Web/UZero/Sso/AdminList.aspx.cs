using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
    public partial class AdminList : AuthPageBase
    {
        IRoleService _roleService = UPrimeEngine.Instance.Resolve<IRoleService>();
        IAdminService _adminService = UPrimeEngine.Instance.Resolve<IAdminService>();
        IAppService _appService = UPrimeEngine.Instance.Resolve<IAppService>();

        protected AdminListModel Model = new AdminListModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSearch.Click += btnSearch_Click;
            if (!Settings.IsSsoOpend)
            {
                Response.Redirect("/UZero/AdminList.aspx");
            }

            if (!IsPostBack)
            {
                Model.Apps = _appService.GetAll(false);

                var roles = _roleService.GetAll().OrderByDescending(x => x.SsoAppId).ToList();
                ddlRole.Items.Clear();
                ddlRole.Items.Add(new ListItem("全部角色", "-1"));
                if (roles != null && Model.Apps != null)
                {
                    foreach (var app in Model.Apps)
                    {
                        ddlRole.Items.Add(new ListItem(app.ToString(), "-1"));

                        foreach (var role in roles.Where(x => x.SsoAppId == app.Id).ToList())
                        {

                            ddlRole.Items.Add(new ListItem(string.Format("{0}- {1}", HttpUtility.HtmlDecode("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"), role.Name), role.Id.ToString()));
                        }
                    }
                }

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

                _adminService.ResetPassword(adminId, newPassword);
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
                    _adminService.Delete(adminId);
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

            var results = _adminService.Search(input);
            rptDatas.DataSource = results.Items;
            rptDatas.DataBind();

            pageInfo.TotalCount = results.TotalCount;
            Model.PagerHtml = new Paginations(pageInfo).GetPaging();
        }
        #endregion

        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindPageDatas(GetUrlParam(), false);
        }

        protected string GetRoleName(AdminDto admin)
        {
            string res = "";
            if (admin != null && admin.Roles != null && admin.Roles.Count > 0)
            {
                foreach (var role in admin.Roles)
                {
                    res += "【" + role.SsoApp.Name + "-" + role.Name + "】";
                }
                if (res.IsNotNullOrEmpty())
                    res = res.TrimEnd(",");
            }
            else
                res = "-";
            return res;
        }
    }

    public class AdminListModel
    {
        public string PagerHtml { get; set; }

        public IList<App> Apps { get; set; }
    }
}