using System;
using System.Web;
using System.Web.Security;
using UZeroConsole.Services.Dto;

namespace UZeroConsole.Services
{
    public class FormsAuthenticationService : IAuthenticationService
    {
        private readonly IAdminService _adminService;
        private readonly TimeSpan _expirationTimeSpan;
        private AdminDto _cachedAdmin;
        public FormsAuthenticationService(IAdminService adminService)
        {
            _adminService = adminService;
            _expirationTimeSpan = FormsAuthentication.Timeout;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="admin">管理员信息</param>
        /// <param name="createPersistentCookie">是否创建固定的cookie</param>
        public void SignIn(AdminDto admin, bool createPersistentCookie = true)
        {
            var now = DateTime.UtcNow.ToLocalTime();
            var ticket = new FormsAuthenticationTicket(
                1 /*version*/,
                admin.Username,
                now,
                now.Add(_expirationTimeSpan),
                createPersistentCookie,
                admin.Id.ToString(),
                FormsAuthentication.FormsCookiePath);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            if (FormsAuthentication.CookieDomain != null)
            {
                cookie.Domain = FormsAuthentication.CookieDomain;
            }

            HttpContext.Current.Response.Cookies.Add(cookie);
            _cachedAdmin = admin;

            _adminService.UpdateLastLoginTime(admin.Id);
        }

        /// <summary>
        /// 登出
        /// </summary>
        public void SignOut() {
            _cachedAdmin = null;
            FormsAuthentication.SignOut();
        }

        /// <summary>
        /// 获取已经通过身份证证的用户
        /// </summary>
        /// <returns></returns>
        public AdminDto GetAuthenticatedAdmin() {
            if (_cachedAdmin != null)
                return _cachedAdmin;

            if (HttpContext.Current == null ||
                HttpContext.Current.Request == null ||
                !HttpContext.Current.Request.IsAuthenticated ||
                !(HttpContext.Current.User.Identity is FormsIdentity))
            {
                return null;
            }

            var formsIdentity = (FormsIdentity)HttpContext.Current.User.Identity;
            var admin = GetAuthenticatedAdminFromTicket(formsIdentity.Ticket);
            if (admin != null)
                _cachedAdmin = admin;

            return _cachedAdmin;
        }

        private AdminDto GetAuthenticatedAdminFromTicket(FormsAuthenticationTicket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException("ticket");

            var adminId = ticket.UserData;

            if (string.IsNullOrWhiteSpace(adminId))
                return null;

            var admin = _adminService.Get(adminId.ToInt());
            return admin;
        }
    }
}
