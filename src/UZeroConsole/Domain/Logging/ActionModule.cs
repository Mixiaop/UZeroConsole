using U.Domain.Entities.Auditing;

namespace UZeroConsole.Domain.Logging
{
    /// <summary>
    /// 活动日志的模块
    /// </summary>
    public class ActionModule : CreationAuditedEntity
    {
        public ActionModule() {
            AppId = 0;
            ModuleName = "";
        }

        /// <summary>
        /// 应用标识
        /// </summary>
        public int AppId { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName { get; set; }


        /// <summary>
        /// 应用信息
        /// </summary>
        public virtual LogApp App { get; set; }
    }
}
