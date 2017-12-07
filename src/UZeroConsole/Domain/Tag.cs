using U.Domain.Entities.Auditing;

namespace UZeroConsole.Domain
{
    /// <summary>
    /// 代表一个“标签”
    /// </summary>
    public class Tag : FullAuditedEntity
    {
        public Tag()
        {
            Name = "";
            Alias = "";
            Count = 1;
            UserId = 0;
            Type = TagType.None;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 别名（“别名”是在URL中使用的别称，它可以令URL更美观。通常使用小写，只能包含字母，数字和连字符（-））
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// 使用次数
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 创建者Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 所属类型Id
        /// </summary>
        public int TypeId { get; set; }

        #region Custom
        /// <summary>
        /// 类型
        /// </summary>
        public TagType Type {
            get { return (TagType)TypeId; }
            set { TypeId = (int)value; }
        }
        #endregion
    }
}
