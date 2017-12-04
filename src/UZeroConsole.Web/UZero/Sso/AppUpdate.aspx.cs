using System;
using U;
using U.Utilities.Web;
using UZeroConsole.Domain.Sso;
using UZeroConsole.Services.Sso;
using UZeroConsole.Services.Sso.Dto;

namespace UZeroConsole.Web.UZero.Sso
{
    public partial class AppUpdate : AuthPageBase
    {
        IAppService _appService = UPrimeEngine.Instance.Resolve<IAppService>();
        App App;
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSave.Click += btnSave_Click;
            App = _appService.Get(WebHelper.GetInt("appId", 0));
            if (App == null)
                Response.Redirect("AppList.aspx");

            if (!IsPostBack)
            {
                tbName.Text = App.Name;
                tbRemark.Text = App.Remark;
                tbReturnUrl.Text = App.ReturnUrl;
            }
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            #region 编辑管理员
            var input = new CreateOrUpdateAppInput();
            input.Name = tbName.Text.Trim();
            input.Remark = tbRemark.Text.Trim();
            input.ReturnUrl = tbReturnUrl.Text.Trim();
            input.Id = App.Id;

            if (input.Name.IsNullOrEmpty())
            {
                ltlMessage.Text = AlertError("名称不能为空");
                return;
            }

            if (input.ReturnUrl.IsNullOrEmpty())
            {
                ltlMessage.Text = AlertError("回调Url不能为空");
                return;
            }

            _appService.CreateOrUpdate(input);
            LogUpdate("修改了Sso应用：", input.Name);
            ltlMessage.Text = AlertSuccess("编辑成功");
            this.RedirectByTime("AppList.aspx", 1000);
            #endregion
        }
    }
}