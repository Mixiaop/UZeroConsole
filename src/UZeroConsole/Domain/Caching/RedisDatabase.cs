using U.Domain.Entities.Auditing;

namespace UZeroConsole.Domain.Caching
{
    public class RedisDatabase : CreationAuditedEntity
    {
        /// <summary>
        /// 所属实例Id
        /// </summary>
        public int InstanceId { get; set; }

        /// <summary>
        /// 当前数据库索引(0-12)
        /// </summary>
        public int Index { get; set; } = 0;

        /// <summary>
        /// 简介
        /// </summary>
        public string Description { get; set; } = "";


        /// <summary>
        /// 所属实例
        /// </summary>
        public virtual RedisInstance Instance { get; set; }
    }
}
