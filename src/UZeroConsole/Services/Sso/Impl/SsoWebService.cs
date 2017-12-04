using System;
using System.Web;
using U.AutoMapper;
using UZeroConsole.Domain.Sso;
using UZeroConsole.Services.Dto;

namespace UZeroConsole.Services.Sso.Impl
{
    public class SsoWebService : ApplicationServiceBase, ISsoWebService
    {
        private IAppService _appService;
        private ISsoAuthenticationService _ssoAuthenticationService;
        private IAuthenticationService _authenticationService;
        public SsoWebService(IAppService appService, ISsoAuthenticationService ssoAuthenticationService, IAuthenticationService authenticationService)
        {
            _appService = appService;
            _ssoAuthenticationService = ssoAuthenticationService;
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// 是否Sso服务端
        /// </summary>
        /// <returns></returns>
        public bool IsServer()
        {
            return this.Settings.IsSsoOpend && this.Settings.IsSsoServer;
        }

        /// <summary>
        /// 获取Sso服务端Url
        /// </summary>
        /// <returns></returns>
        public string GetServerLoginUrl()
        {
            var host = this.Settings.SsoServerHost;
            if (!host.EndsWith("/"))
                host += "/";

            host += "SysLogin.aspx?ssoAppKey=" + this.Settings.SsoAppKey;

            return host;
        }

        /// <summary>
        /// 创建多平台通用的session，并跳转到授权页开始依次授权
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="returnAppKey">授权完最后的回调应用key</param>
        public void CreateSessionRedirectToSignIn(AdminDto dto, string returnAppKey)
        {
            var context = HttpContext.Current;
            if (context == null)
            {
                throw new Exception("HttpContext.Current is null");
            }
            if (dto == null)
                throw new Exception("dto is null");

            if (returnAppKey.IsNullOrEmpty())
            {
                returnAppKey = this.Settings.SsoAppKey;
            }

            var session = _ssoAuthenticationService.CreateSession(dto, returnAppKey);

            var app = _appService.GetByKey(returnAppKey);
            if (app != null && app.ReturnUrl.IsNotNullOrEmpty())
            {
                string url = string.Format("{0}{1}UZeroSOA/Sso/SignIn.aspx?session={2}",
                                           app.ReturnUrl,
                                           (app.ReturnUrl.EndsWith("/") ? "" : "/"),
                                           session.SessionKey);

                context.Response.Redirect(url);
                context.Response.End();
            }
        }

        /// <summary>
        /// 授权并执行下一个授权
        /// </summary>
        /// <param name="session"></param>
        public void SignInAndContinue(AdminAuthSession session) {
            var context = HttpContext.Current;
            if (context == null)
            {
                throw new Exception("HttpContext.Current is null");
            }

            if (session == null)
            {
                throw new Exception("session is null");
            }

            //授权当前应用
            _ssoAuthenticationService.Authorization(session.SessionKey, this.Settings.SsoAppKey);
            AdminDto admin = session.Admin.MapTo<AdminDto>();
            _authenticationService.SignIn(admin);
            
            string[] appKeys = session.AppKeys.Split(",");
            string nextAppKey = "";
            if (appKeys != null && appKeys.Length > 0){
                foreach (string appKey in appKeys) {
                    if (!session.AuthedAppKeys.Contains(appKey) && appKey.IsNotNullOrEmpty()) {
                        nextAppKey = appKey;
                        break;
                    }
                }
            }

            if (nextAppKey.IsNotNullOrEmpty())
            {
                var app = _appService.GetByKey(nextAppKey);
                if (app != null) {
                    string url = string.Format("{0}{1}UZeroSOA/Sso/SignIn.aspx?session={2}",
                                           app.ReturnUrl,
                                           (app.ReturnUrl.EndsWith("/") ? "" : "/"),
                                           session.SessionKey);
                    context.Response.Redirect(url);
                    context.Response.End();
                }
            }
            else {
                var app = _appService.GetByKey(session.CurrentAppKey);
                if (app != null)
                {
                    context.Response.Redirect(app.ReturnUrl);
                    context.Response.End();
                }
            }
        }
    }
}
