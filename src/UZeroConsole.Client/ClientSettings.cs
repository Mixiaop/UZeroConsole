using U.Settings;

namespace UZeroConsole.Client
{
    [USettingsPathArribute("ClientSettings.json", "/Config/UZeroConsole/")]
    public class ClientSettings : USettings<ClientSettings>
    {
        public string JobsSoaHost { get; set; }

        /// <summary>
        /// 日志模块默认SOA（日志中心） 如 http://log.youzy.cn
        /// </summary>
        public string LoggingSoaHost { get; set; }

        /// <summary>
        /// 当前应用默认使用的密钥
        /// 如 单应用使用多个密钥，可通过参数传递
        /// </summary>
        public string LoggingDefaultKey { get; set; }

        //Config center
        ///// <summary>
        ///// 配置远程服务器地址，多个以逗号“,”分割（示例：http://127.0.0.1:8000,http://127.0.0.1:8000）
        ///// </summary>
        //public string ServerHost { get; set; }

        ///// <summary>
        ///// 默认使用的项目KEY
        ///// </summary>
        //public string DefaultProjectKey { get; set; }

        ///// <summary>
        ///// 是否为 debug env，默认 false
        ///// </summary>
        //public bool IsDebug { get; set; }

        ///// <summary>
        ///// 获取远程配置 重试次数，默认是3次
        ///// </summary>
        //public int RetryTimes { get; set; }

        ///// <summary>
        ///// 获取远程配置 重试时休眠时间，默认是5秒
        ///// </summary>
        //public int RetrySleepSeconds { get; set; }
    }
}
