using U.Domain.Entities.Auditing;

namespace UZeroConsole.Domain.CMS
{
    /// <summary>
    /// 内容组信息
    /// </summary>
    public class ContentGroup : CreationAuditedEntity
    {
        public ContentGroup() {
            ContentGroupName = "";
            Description = "";
        }

        /// <summary>
        /// 内容组名称
        /// </summary>
        public string ContentGroupName { get; set; }

        /// <summary>
        /// 内容组介绍
        /// </summary>
        public string Description { get; set; }
    }
}
