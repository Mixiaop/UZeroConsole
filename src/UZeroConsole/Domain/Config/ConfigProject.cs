using U.Domain.Entities.Auditing;

namespace UZeroConsole.Domain.Config
{
    /// <summary>
    /// 代表一个“配置项目”
    /// 如：Zero、ZeroB、UZeroConsole
    /// </summary>
    public class ConfigProject : CreationAuditedEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }
    }
}
