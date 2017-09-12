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
        /// 别名代码（唯一）
        /// 可能在后面的服务中当参数使用获取配置信息
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 密钥可用于配置指定项目
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }
    }
}
