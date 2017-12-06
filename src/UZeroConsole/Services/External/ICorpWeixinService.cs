using UZeroConsole.Services.External.Dto;
namespace UZeroConsole.Services.External
{
    /// <summary>
    /// 企业微信服务
    /// </summary>
    public interface ICorpWeixinService : IApplicationService
    {
        /// <summary>
        /// 获取访问令牌
        /// </summary>
        /// <returns></returns>
        GetCorpWexinAccessTokenOutput GetAccessToken();

        /// <summary>
        /// 获取用户Id
        /// </summary>
        /// <param name="accessToken">令牌</param>
        /// <param name="code">回调code</param>
        /// <returns></returns>
        GetCorpWeixinUserIdOutput GetUserId(string accessToken, string code);
    }
}
