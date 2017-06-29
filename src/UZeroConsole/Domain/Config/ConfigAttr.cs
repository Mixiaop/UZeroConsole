using U.Domain.Entities.Auditing;

namespace UZeroConsole.Domain.Config
{
    /// <summary>
    /// 代表一个“配置对象的属性”
    /// 某个Config的一项Key、Value属性
    /// </summary>
    public class ConfigAttr : CreationAuditedEntity
    {
        /// <summary>
        /// 键
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 所属项目Id
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// 所属对象Id
        /// </summary>
        public int ObjectId { get; set; }

        /// <summary>
        /// 所属项目
        /// </summary>
        public virtual ConfigProject Project { get; set; }

        /// <summary>
        /// 所属对象
        /// </summary>
        public virtual ConfigObject Object { get; set; }
    }
}
