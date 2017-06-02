using UZeroConsole.Services.Dto;

namespace UZeroConsole.Services
{
    /// <summary>
    /// 控制台身份验证服务（登录、登出）
    /// </summary>
    public interface IAuthenticationService : U.Application.Services.IApplicationService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="admin">管理员信息</param>
        /// <param name="createPersistentCookie">是否创建固定的cookie</param>
        void SignIn(AdminDto admin, bool createPersistentCookie);

        /// <summary>
        /// 登出
        /// </summary>
        void SignOut();

        /// <summary>
        /// 获取已经通过身份证证的用户
        /// </summary>
        /// <returns></returns>
        AdminDto GetAuthenticatedAdmin();
    }
}
