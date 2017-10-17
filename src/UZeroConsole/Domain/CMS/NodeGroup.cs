using U.Domain.Entities.Auditing;

namespace UZeroConsole.Domain.CMS
{
    /// <summary>
    /// 栏目组信息描述
    /// </summary>
    public class NodeGroup : CreationAuditedEntity
    {
        public NodeGroup() {
            NodeGroupName = "";
            Description = "";
        }

        /// <summary>
        /// 栏目组名称
        /// </summary>
        public string NodeGroupName { get; set; }

        /// <summary>
        /// 栏目组介绍
        /// </summary>
        public string Description { get; set; }
    }
}
