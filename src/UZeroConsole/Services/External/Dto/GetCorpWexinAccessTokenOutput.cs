namespace UZeroConsole.Services.External.Dto
{
    /// <summary>
    /// 获取AccessToken
    /// </summary>
    public class GetCorpWexinAccessTokenOutput : CorpWeixinResponseDto
    {
        public string access_token { get; set; }

        /// <summary>
        /// 过期时间（秒）
        /// 正常情况下AccessToken有效期为7200秒，有效期内重复获取返回相同结果。
        /// </summary>
        public int expires_in { get; set; }
    }
}
