using U.Domain.Entities.Auditing;

namespace UZeroConsole.Domain.Logging
{
    /// <summary>
    /// 活动日志
    /// </summary>
    public class ActionLog : CreationAuditedEntity
    {
        public ActionLog() {
            AppId = 0;
            ModuleName = "";
            OperateType = ActionLogOperateType.None;
            ShortMessage = "";
            FullMessage = "";
            IpAddress = "";
            Url = "";
            UserAgent = "";
            Operator = "";
            OperatorId = "";
            Remark = "";
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
        /// 日志操作类型（CURD）
        /// </summary>
        public int OperateTypeId { get; set; }

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
        /// 日志URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// User agent
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// 操作者
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// 操作者标识
        /// </summary>
        public string OperatorId { get; set; }

        /// <summary>
        /// 备注（一般用于操作者说明）
        /// </summary>
        public string Remark { get; set; }

        #region Navi / Custom
        /// <summary>
        /// 应用
        /// </summary>
        public virtual LogApp App { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public ActionLogOperateType OperateType
        {
            get { return (ActionLogOperateType)OperateTypeId; }
            set { OperateTypeId = (int)value; }
        }
        #endregion
    }
}
