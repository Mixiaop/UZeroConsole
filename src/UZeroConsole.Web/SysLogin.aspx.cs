using System;
using Newtonsoft.Json;
using U;
using U.UI;
using U.Utilities.Web;
using UZeroConsole.Configuration;
using UZeroConsole.Services;
using UZeroConsole.Services.Dto;
using UZeroConsole.Services.Sso;
using UZeroConsole.Services.External;

namespace UZeroConsole.Web
{
    public partial class SysLogin : PageBase
    {
        IAppService _appService = UPrimeEngine.Instance.Resolve<IAppService>();
        ISsoWebService _ssoService = UPrimeEngine.Instance.Resolve<ISsoWebService>();
        ICorpWeixinService _weixinService = UPrimeEngine.Instance.Resolve<ICorpWeixinService>();
        IAuthenticationService _authService = UPrimeEngine.Instance.Resolve<IAuthenticationService>();
        IAdminService _adminService = UPrimeEngine.Instance.Resolve<IAdminService>();

        protected SysLoginModel Model = new SysLoginModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnLogin.Click += btnLogin_Click;
            Model.WeixinSettings = UPrimeEngine.Instance.Resolve<CorpWeixinSettings>();
            Model.Title = this.Settings.Title;

            if (this.Settings.IsCorpWeixinLoginOpened)
            {
                #region 企业微信登录回调
                var code = WebHelper.GetString("code");
                if (code.IsNotNullOrEmpty()) {
                    AdminDto admin = new AdminDto();
                    var token = _weixinService.GetAccessToken();
                    if (token.IsSuccess()) {
                        var user = _weixinService.GetUserId(token.access_token, code);
                        if (user.IsSuccess()) {
                            admin = _adminService.GetByCorpWeixinUserId(user.UserId);
                        }
                    }

                    if (admin.Id > 0)
                    {
                        if (this.Settings.IsSsoOpend && !this.Settings.IsDebug)
                        {
                            #region Sso
                            _ssoService.CreateSessionRedirectToSignIn(admin, Model.GetSsoAppKey);
                            #endregion
                        }
                        else
                        {
                            _authService.SignIn(admin, true);

                            if (Model.GetRedirectUrl.IsNullOrEmpty())
                                Response.Redirect("/");
                            else
                                Response.Redirect(Model.GetRedirectUrl);
                        }
                    }
                }
                #endregion
            }

            #region Sso
            if (this.Settings.IsSsoOpend && !this.Settings.IsDebug)
            {
                if (!_ssoService.IsServer())
                {
                    Response.Redirect(_ssoService.GetServerLoginUrl());
                    Response.End();
                }
            }
            #endregion

            if (!IsPostBack)
            {
                //获取记住的用户
                var rememberUser = GetCookieUser();
                if (rememberUser != null)
                {
                    cbRememberMe.Checked = true;
                    tbUsername.Text = rememberUser.Username;
                }
            }
        }

        void btnLogin_Click(object sender, EventArgs e)
        {
            #region 登录
            var username = tbUsername.Text.Trim();
            var password = tbPassword.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                ltlError.Text = AlertError("用户名不能为空");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                ltlError.Text = AlertError("密码不能为空");
                return;
            }

            bool isHuman = loginCaptcha.Validate(tbCaptchaCode.Text);

            tbCaptchaCode.Text = null;

            if (!isHuman)
            {
                ltlError.Text = AlertError("验证码有误");
                return;
            }


            try
            {
                if (cbRememberMe.Checked)
                {
                    //记住我
                    SetCookieUser(username, password);
                }
                else
                {
                    //清除
                    ClearCookieUser();
                }

                IAdminService adminService = UPrimeEngine.Instance.Resolve<IAdminService>();
                IAuthenticationService authService = UPrimeEngine.Instance.Resolve<IAuthenticationService>();
                var admin = adminService.Validation(username, password);
                if (admin != null)
                {
                    #region 开启UNOTE
                    if (WebHelper.GetInt("unote", 0) == 1 && this.Settings.UNoteExternalLoginOpened && admin.UNoteUsername.IsNotNullOrEmpty())
                    {
                        Response.Redirect(string.Format("{0}?appkey={1}&username={2}", this.Settings.UNoteExternalLoginUrl, this.Settings.UNoteAppKey, admin.UNoteUsername));
                        Response.End();
                    }
                    #endregion

                    if (this.Settings.IsSsoOpend && !this.Settings.IsDebug)
                    {
                        #region Sso
                        _ssoService.CreateSessionRedirectToSignIn(admin, Model.GetSsoAppKey);
                        #endregion
                    }
                    else
                    {
                        authService.SignIn(admin, true);

                        if (Model.GetRedirectUrl.IsNullOrEmpty())
                            Response.Redirect("/");
                        else
                            Response.Redirect(Model.GetRedirectUrl);
                    }
                }
            }
            catch (UserFriendlyException ex)
            {
                ltlError.Text = AlertError(ex.Message);
            }

            #endregion
        }

        #region CookieUser
        string COOKIE_USER_NAME = UPrimeEngine.Instance.Resolve<ConsoleSettings>().AppName + "_RememberUser";
        public class RememberUser
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        void SetCookieUser(string username, string password)
        {
            if (username.IsNotNullOrEmpty() && password.IsNotNullOrEmpty())
            {
                var rememberUserExpiresTime = 525600;
                var expiresTime = DateTime.Now.AddMinutes(rememberUserExpiresTime);
                var user = new RememberUser();
                user.Username = username;
                user.Password = password;
                var value = JsonConvert.SerializeObject(user).EncodeUTF8Base64();
                CookieHelper.SetCookie(COOKIE_USER_NAME, value, expiresTime);
            }
        }

        RememberUser GetCookieUser()
        {
            var value = CookieHelper.GetCookieValue(COOKIE_USER_NAME);
            if (value.IsNotNullOrEmpty())
                return JsonConvert.DeserializeObject<RememberUser>(value.DecodeUTF8Base64());
            else
                return null;
        }

        void ClearCookieUser()
        {
            CookieHelper.ClearCookie(COOKIE_USER_NAME);
        }
        #endregion
    }

    public class SysLoginModel
    {
        public string GetSsoAppKey { get { return WebHelper.GetString("ssoAppKey"); } }
        public string GetRedirectUrl { get { return WebHelper.GetString("redirectUrl"); } }

        public string Title { get; set; }

        public CorpWeixinSettings WeixinSettings { get; set; }
    }
}