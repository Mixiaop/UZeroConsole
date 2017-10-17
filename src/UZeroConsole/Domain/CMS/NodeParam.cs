using U.Domain.Entities.Auditing;

namespace UZeroConsole.Domain.CMS
{
    /// <summary>
    /// 栏目参数
    /// </summary>
    public class NodeParam : CreationAuditedEntity
    {
        /// <summary>
        /// 栏目Id
        /// </summary>
        public int NodeId { get; set; }
        /// <summary>
        /// 参数ID
        /// </summary>
        public int ParamId { get; set; }
    }
}
