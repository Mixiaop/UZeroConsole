using U.Settings;

namespace UZeroConsole.Configuration
{
    [USettingsPathArribute("ConfigClientSettings.json", "/Config/UZeroConsole")]
    public class ConfigClientSettings : USettings<ConfigClientSettings>
    {
        /// <summary>
        /// 配置远程服务器地址，多个以逗号“,”分割（示例：http://127.0.0.1:8000,http://127.0.0.1:8000）
        /// </summary>
        public string ServerHost { get; set; }

        /// <summary>
        /// 当前使用的项目KEY
        /// </summary>
        public string ProjectKey { get; set; }
        
        /// <summary>
        /// 是否为 debug env，默认 false
        /// </summary>
        public bool IsDebug { get; set; }

        /// <summary>
        /// 获取远程配置 重试次数，默认是3次
        /// </summary>
        public int RetryTimes { get; set; }

        /// <summary>
        /// 获取远程配置 重试时休眠时间，默认是5秒
        /// </summary>
        public int RetrySleepSeconds { get; set; }
    }
}
