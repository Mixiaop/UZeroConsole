using System;
using Newtonsoft.Json;
using U;
using U.UI;
using U.Utilities.Web;
using UZeroConsole.Configuration;
using UZeroConsole.Services;

namespace UZeroConsole.Web
{
    public partial class SysLogin : PageBase
    {
        protected ConsoleSettings ConsoleSettings = UPrimeEngine.Instance.Resolve<ConsoleSettings>();
        protected string redirectUrl;
        protected void Page_Load(object sender, EventArgs e)
        {
            btnLogin.Click += btnLogin_Click;
            redirectUrl = WebHelper.GetString("redirectUrl");
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
                    authService.SignIn(admin, true);
                    adminService.UpdateLastLoginTime(admin.Id);
                    if (redirectUrl.IsNullOrEmpty())
                        Response.Redirect("/");
                    else
                        Response.Redirect(redirectUrl);
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
}