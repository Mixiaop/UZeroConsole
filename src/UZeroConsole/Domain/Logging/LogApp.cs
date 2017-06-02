using System;
using U.Domain.Entities.Auditing;

namespace UZeroConsole.Domain.Logging
{
    /// <summary>
    /// 日志应用
    /// 代表一个使用日志模块的应用说明及密钥
    /// </summary>
    public class LogApp : CreationAuditedEntity
    {
        public LogApp() {
            Name = "";
            Description = "";
            Key = "";
            IsTests = false;
            LastActionTime = null;
            LastActionTime = null;
        }

        /// <summary>
        /// 应用名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 是否测试应用
        /// </summary>
        public bool IsTests { get; set; }

        /// <summary>
        /// 唯一密钥（自动生成）
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 最后一次异常时间
        /// </summary>
        public DateTime? LastExceptionTime { get; set; }

        /// <summary>
        /// 最后一次操作时间
        /// </summary>
        public DateTime? LastActionTime { get; set; }
    }
}
