using System;
using System.Linq;
using U.Utilities.Web;
using UZeroConsole.Domain;
using UZeroConsole.Domain.Sso;
using UZeroConsole.Domain.Sso.Repositories;
using UZeroConsole.Services;
using UZeroConsole.Services.Dto;

namespace UZeroConsole.Services.Sso.Impl
{
    public class SsoAuthenticationService : ApplicationServiceBase, ISsoAuthenticationService
    {
        IAdminAuthSessionRepository _adminAuthSessionRepository;
        IAppService _appService;
        public SsoAuthenticationService(IAdminAuthSessionRepository adminAuthSessionRepository, IAppService appService)
        {
            _adminAuthSessionRepository = adminAuthSessionRepository;
            _appService = appService;
        }

        /// <summary>
        /// 通过key获取session
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <returns></returns>
        public AdminAuthSession GetSession(string sessionKey) {
            sessionKey = sessionKey.Trim();
            var info = _adminAuthSessionRepository.GetAll().Where(x => x.SessionKey == sessionKey).FirstOrDefault();
            return info;
        }

        /// <summary>
        /// 用户验证成功后创建并返回session
        /// </summary>
        /// <param name="admin"></param>
        /// <param name="currentAppKey">当前登录的应用</param>
        /// <returns></returns>
        public AdminAuthSession CreateSession(AdminDto admin, string currentAppKey = "")
        {
            AdminAuthSession session = new AdminAuthSession();
            if (admin != null)
            {
                session.CurrentAppKey = currentAppKey;
                session.SessionKey = Guid.NewGuid().ToString().Replace("-", "");
                session.ExpiresTime = DateTime.Now.AddMinutes(this.Settings.SsoAuthExpiresMinutes);
                session.AdminId = admin.Id;
                session.IpAddress = WebHelper.GetIP();
                if (admin.IsSuperAdmin())
                {
                    var apps = _appService.GetAll(false);
                    if (apps != null) {
                        foreach (var app in apps) {
                            session.AppKeys += app.AppKey + ",";
                        }
                        session.AppKeys = session.AppKeys.TrimEnd(",");
                    }
                }
                else
                {
                    if (admin.Roles != null)
                    {
                        foreach (var role in admin.Roles)
                        {
                            if (role.SsoApp != null && !session.AppKeys.Contains(role.SsoApp.AppKey))
                            {
                                if (session.CurrentAppKey.IsNullOrEmpty())
                                    session.CurrentAppKey = role.SsoApp.AppKey;

                                session.AppKeys += role.SsoApp.AppKey + ",";
                            }
                        }

                        session.AppKeys = session.AppKeys.TrimEnd(",");
                    }
                }
                session.Id = _adminAuthSessionRepository.InsertAndGetId(session);
            }
            return session;
        }

        /// <summary>
        /// 登录后授权应用
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="appKey"></param>
        public void Authorization(string sessionKey, string appKey) {
            var session = _adminAuthSessionRepository.GetAll().Where(x => x.SessionKey == sessionKey).FirstOrDefault();
            if (session != null) {
                if (!session.AuthedAppKeys.Contains(appKey)) {
                    session.AuthedAppKeys += (session.AuthedAppKeys.IsNotNullOrEmpty() ? "," : "") + appKey;
                    _adminAuthSessionRepository.Update(session);
                }
            }
        }
    }
}
