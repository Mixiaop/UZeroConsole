using U.Domain.Entities.Auditing;

namespace UZeroConsole.Domain.Logging
{
    /// <summary>
    /// 异常
    /// </summary>
    public class ExceptionLog : CreationAuditedEntity
    {
        public ExceptionLog() {
            AppId = 0;
            MachineName = "";
            Type = "";
            ShortMessage = "";
            FullMessage = "";
            IpAddress = "";
            Host = "";
            Url = "";
            UserAgent = "";
            HttpMethod = "";
            StatusCode = "";
        }

        /// <summary>
        /// 应用标识
        /// </summary>
        public int AppId { get; set; }

        /// <summary>
        /// 机器名
        /// </summary>
        public string MachineName { get; set; }

        /// <summary>
        /// 异常类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 短消息
        /// </summary>
        public string ShortMessage { get; set; }

        /// <summary>
        /// 详细信息
        /// </summary>
        public string FullMessage { get; set; }

        /// <summary>
        /// Ip address
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// Host
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 日志URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// User agent
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// 请求类型
        /// </summary>
        public string HttpMethod { get; set; }

        /// <summary>
        /// 状态码
        /// </summary>
        public string StatusCode { get; set; }

        /// <summary>
        /// 应用信息
        /// </summary>
        public virtual LogApp App { get; set; }
    }
}
