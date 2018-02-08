using System.Collections.Generic;
using U.Settings;

namespace UZeroConsole.Configuration.Monitoring
{
    /// <summary>
    /// 警告时通知配置
    /// </summary>

    [USettingsPathArribute("AlertSettings.json", "/Config/UZeroConsole/Monitoring/")]
    public class AlertSettings : USettings<AlertSettings>
    {
        /// <summary>
        /// 客户端Cpu警告值（通知）
        /// </summary>
        public int WebServerCPUWarning { get; set; }

        /// <summary>
        /// 客户端内存警告值（通知）
        /// </summary>
        public int WebServerMemoryWarning { get; set; }

        /// <summary>
        /// SQL服务器CPU警告值
        /// </summary>
        public int SqlCPUWarning { get; set; }

        /// <summary>
        /// SQL服务器内存警告值
        /// </summary>
        public int SqlMemoryWarning { get; set; }

        /// <summary>
        /// Redis每秒OPS警告值
        /// </summary>
        public int RedisOpsPerSecWarning { get; set; }

        /// <summary>
        /// Redis使用内存警告值
        /// </summary>
        public int RedisUsedMemoryWarning { get; set; }

        /// <summary>
        /// 接收通知的企业微信Id
        /// </summary>
        public List<string> CorpWeixinIdList { get; set; }

        /// <summary>
        /// 接收通知的邮箱地址
        /// </summary>
        public List<string> Emails { get; set; }
    }
}



