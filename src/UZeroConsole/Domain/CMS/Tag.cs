using U.Domain.Entities.Auditing;
namespace UZeroConsole.Domain.CMS
{
    /// <summary>
    /// 内容的标签信息
    /// </summary>
    public class Tag : CreationAuditedEntity
    {
        public Tag() {
            TagName = "";
            UsedCount = 0;
        }

        /// <summary>
        /// 标签名称
        /// </summary>
        public string TagName { get; set; }

        /// <summary>
        /// 使用次数
        /// </summary>
        public int UsedCount { get; set; }
    }
}
