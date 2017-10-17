using U.Domain.Entities.Auditing;

namespace UZeroConsole.Domain.CMS
{
    /// <summary>
    /// 内容参数
    /// </summary>
    public class ContentParam : CreationAuditedEntity
    {
        public ContentParam() {
            ContentId = 0;
            ParamId = 0;
            Text = "";
            Value = "";
        }

        /// <summary>
        /// 内容ID
        /// </summary>
        public int ContentId { get; set; }

        /// <summary>
        /// 参数ID
        /// </summary>
        public int ParamId { get; set; }

        /// <summary>
        /// 参数内容
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 参数值
        /// </summary>
        public string Value { get; set; }
    }
}
