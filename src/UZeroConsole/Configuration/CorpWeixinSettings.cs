using U.Settings;

namespace UZeroConsole.Configuration
{
    /// <summary>
    /// 企业微信配置
    /// </summary>
    [USettingsPathArribute("CorpWeixinSettings.json", "/Config/UZeroConsole/")]
    public class CorpWeixinSettings: USettings<CorpWeixinSettings>
    {
        /// <summary>
        /// 企业Id
        /// </summary>
        public string CorpId { get; set; }

        /// <summary>
        /// 授权应用Id
        /// </summary>
        public string AuthAgentId { get; set; }

        /// <summary>
        /// 授权应用密钥
        /// </summary>
        public string AuthSecret { get; set; }
    }
}
