using U.Domain.Entities.Auditing;

namespace UZeroConsole.Domain.Caching
{
    /// <summary>
    /// Redis 实例
    /// </summary>
    public class RedisInstance : CreationAuditedEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// 简介 
        /// </summary>
        public string Description { get; set; } = "";

        /// <summary>
        /// IP地址
        /// </summary>
        public string Host { get; set; } = "";

        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; } = 6379;
    }
}
