using UZeroConsole.Domain.Sso;
using UZeroConsole.Services.Dto;

namespace UZeroConsole.Services.Sso
{
    /// <summary>
    /// Sso有关的业务服务
    /// </summary>
    public interface ISsoWebService : IApplicationService
    {
        /// <summary>
        /// 是否Sso服务端
        /// </summary>
        /// <returns></returns>
        bool IsServer();

        /// <summary>
        /// 获取Sso服务端Url
        /// </summary>
        /// <returns></returns>
        string GetServerLoginUrl();

        /// <summary>
        /// 创建多平台通用的session，并跳转到授权页开始依次授权
        /// </summary>
        /// <param name="dto">管理员信息</param>
        /// <param name="returnAppKey">授权完最后的回调应用key</param>
        void CreateSessionRedirectToSignIn(AdminDto dto, string returnAppKey);

        /// <summary>
        /// 授权并执行下一个授权
        /// </summary>
        /// <param name="session"></param>
        void SignInAndContinue(AdminAuthSession session);
    }
}
