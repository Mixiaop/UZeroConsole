using UZeroConsole.Domain.Sso;
using UZeroConsole.Services.Dto;

namespace UZeroConsole.Services.Sso
{
    /// <summary>
    /// Sso身份验证服务
    /// </summary>
    public interface ISsoAuthenticationService : IApplicationService
    {
        /// <summary>
        /// 通过key获取session
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <returns></returns>
        AdminAuthSession GetSession(string sessionKey);

        /// <summary>
        /// 用户验证成功后创建并返回session
        /// </summary>
        /// <param name="admin"></param>
        /// <param name="currentAppKey">当前登录的应用</param>
        /// <returns></returns>
        AdminAuthSession CreateSession(AdminDto admin, string currentAppKey = "");

        /// <summary>
        /// 登录后授权应用
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="appKey"></param>
        void Authorization(string sessionKey, string appKey);
    }
}
