using U.Settings;

namespace UZeroConsole.Configuration
{
    [USettingsPathArribute("LoggingSettings.json", "/Config/UZeroConsole")]
    public class LoggingSettings : USettings<LoggingSettings>
    {
        /// <summary>
        /// 日志模块默认SOA（日志中心） 如 http://log.youzy.cn
        /// </summary>
        public string SOAHost { get; set; }

        /// <summary>
        /// 当前应用默认使用的密钥
        /// 如 单应用使用多个密钥，可通过参数传递
        /// </summary>
        public string DefaultKey { get; set; }
    }
}
