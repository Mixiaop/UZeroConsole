using System;
using System.Web.UI.WebControls;
using U;
using U.Utilities.Web;
using UZeroConsole.Services.Sso;

namespace UZeroConsole.Web.UZero.Sso
{
    public partial class AppList : AuthPageBase
    {
        IAppService _appService = UPrimeEngine.Instance.Resolve<IAppService>();
        protected string PagerHtml;
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSearch.Click += btnSearch_Click;
            if (!IsPostBack)
            {
                tbSearchKeywords.Text = WebHelper.GetString("wd");
                BindPageDatas(GetUrlParam(), true);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            #region 删除
            try
            {
                LinkButton lb = (LinkButton)sender;
                int id = Convert.ToInt32(lb.CommandArgument);
                var app = _appService.Get(id);
                if (app !=null)
                {
                    
                    _appService.Delete(id);
                    LogDelete("删除了Sso应用：", app.Name);
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
            pageInfo.Url = url == "" ? WebHelper.GetUrl() : "AppList.aspx?" + url;


            var results = _appService.Query(tbSearchKeywords.Text.Trim(), pageInfo.PageIndex, pageInfo.PageSize);
            rptDatas.DataSource = results.Items;
            rptDatas.DataBind();

            pageInfo.TotalCount = results.TotalCount;
            PagerHtml = new Paginations(pageInfo).GetPaging();
        }
        #endregion
    }
}