using System;
using U.Domain.Entities.Auditing;

namespace UZeroConsole.Domain.Jobs
{
    /// <summary>
    /// 代表一个远程任务（一个外网可访问的URL任务）
    /// 指定的时间访问这个任务【一般为外网可访问的链接，如 http://www.youzy.cn/jobs/update】
    /// </summary>
    public class RemoteJob  : CreationAuditedEntity
    {
        public RemoteJob() {
            Key = "";
            Name = "";
            Url = "";
            Desc = "";
            Type = RemoteJobType.General;
            LastSuccessTime = null;
            LastErrorTime = null;
            LastErrorDesc = "";
            RecurringSeconds = 0;
            AtTime = null;
            AppJobId = "";
            Tags = "";
        }

        /// <summary>
        /// 唯一标识（如 KeepAlive）
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 任务名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 触发任务的URL（必须外网可访问，如 http://www.youzy.cn/jobs/update）
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 任务描述
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// 是否执行中
        /// </summary>
        public bool IsExecuting { get; set; }

        /// <summary>
        /// 任务最后一次的成功时间
        /// </summary>
        public DateTime? LastSuccessTime { get; set; }

        /// <summary>
        /// 任务最后一次的执行错误的时间
        /// </summary>
        public DateTime? LastErrorTime { get; set; }

        /// <summary>
        /// 任务最后一次的执行错误描述
        /// </summary>
        public string LastErrorDesc { get; set; }

        /// <summary>
        /// 任务类型
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// 循环任务的时间（每多少分钟执行）,当循环类型时才使用
        /// </summary>
        public int RecurringSeconds { get; set; }

        /// <summary>
        /// 定时任务时使用（指定的时间）
        /// </summary>
        public DateTime? AtTime { get; set; }

        /// <summary>
        /// 外部应用任务标识（如：Hangfire、Quantz）
        /// </summary>
        public string AppJobId { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public string Tags { get; set; }

        #region Custom
        /// <summary>
        /// 任务类型
        /// </summary>
        public RemoteJobType Type {
            get { return (RemoteJobType)TypeId; }
            set { TypeId = (int)value; }
        }

        /// <summary>
        /// 是否已开启
        /// </summary>
        public bool Opend { get { return AppJobId.IsNotNullOrEmpty(); } }
        #endregion
    }
}
