using System;
using U;
using U.Utilities.Web;
using UZeroConsole.Services.Sso;
using UZeroConsole.Services.Sso.Dto;

namespace UZeroConsole.Web.UZero.Sso
{
    public partial class AppCreate : AuthPageBase
    {
        IAppService _appService = UPrimeEngine.Instance.Resolve<IAppService>();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSave.Click += btnSave_Click;
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            #region 添加
            try
            {
                var input = new CreateOrUpdateAppInput();
                input.Name = tbName.Text.Trim();
                input.Remark = tbRemark.Text.Trim();
                input.ReturnUrl = tbReturnUrl.Text.Trim();

                if (input.Name.IsNullOrEmpty())
                {
                    ltlMessage.Text = AlertError("名称不能为空");
                    return;
                }

                if (input.ReturnUrl.IsNullOrEmpty()) {
                    ltlMessage.Text = AlertError("回调Url不能为空");
                    return;
                }
                _appService.CreateOrUpdate(input);

                LogInsert("添加了Sso应用：", input.Name);
                ltlMessage.Text = AlertSuccess("添加成功");
                this.RedirectByTime("AppList.aspx", 1000);
            }
            catch (Exception ex)
            {
                LogError(ex.Message, ex);
                ltlMessage.Text = AlertError(ex.Message);
                return;
            }
            #endregion
        }
    }
}