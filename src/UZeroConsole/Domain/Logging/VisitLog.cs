using U.Domain.Entities;

namespace UZeroConsole.Domain.Logging
{
    /// <summary>
    /// 访问日志（快速记录URL）
    /// </summary>
    public class VisitLog : Entity
    {
        public VisitLog() {
            AppId = 0;
            IpAddress = "";
            Url = "";
            UserAgent = "";
            Visitor = "";
            VisitorId = "";
        }

        /// <summary>
        /// 应用标识
        /// </summary>
        public int AppId { get; set; }

        /// <summary>
        /// Ip address
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// 日志URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// User agent
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// 浏览者
        /// </summary>
        public string Visitor { get; set; }

        /// <summary>
        /// 浏览者标识
        /// </summary>
        public string VisitorId { get; set; }

        /// <summary>
        /// 应用信息
        /// </summary>
        public virtual LogApp App { get; set; }
    }
}
