using System;
using U;
using U.Utilities.Web;
using UZeroConsole.Configuration;
using UZeroConsole.Services;
using UZeroConsole.Services.External;

namespace UZeroConsole.Web.UZero
{
    /// <summary>
    /// 绑定企业微信帐号
    /// </summary>
    public partial class AdminBindCorpWeixin : System.Web.UI.Page
    {
        IAdminService _adminService = UPrimeEngine.Instance.Resolve<IAdminService>();
        ICorpWeixinService _weixinService = UPrimeEngine.Instance.Resolve<ICorpWeixinService>();

        protected AdminBindCorpWeixinModel Model = new AdminBindCorpWeixinModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Model.GetAdminId == 0)
            {
                Response.Redirect("AdminList.aspx");
                Response.End();
            }

            Model.Settings = UPrimeEngine.Instance.Resolve<CorpWeixinSettings>();

            #region Bind
            try
            {
                var code = WebHelper.GetString("code");
                if (code.IsNotNullOrEmpty())
                {
                    var accessToken = _weixinService.GetAccessToken();
                    if (accessToken.IsSuccess())
                    {
                        var user = _weixinService.GetUserId(accessToken.access_token, code);
                        if (user.IsSuccess())
                        {
                            _adminService.BindCorpWeixin(Model.GetAdminId, user.UserId);
                            Response.Write("SUCCESS");
                        }
                    }
                }
            }
            catch (Exception ex) {
                Response.Write(ex.Message);
            }
            #endregion

        }
    }

    public class AdminBindCorpWeixinModel
    {
        public int GetAdminId { get { return WebHelper.GetInt("adminId", 0); } }

        public CorpWeixinSettings Settings { get; set; }
    }
}