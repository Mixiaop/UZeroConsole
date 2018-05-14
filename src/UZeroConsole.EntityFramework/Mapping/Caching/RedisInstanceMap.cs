using UZeroConsole.Domain.Caching;

namespace UZeroConsole.EntityFramework.Mapping.Caching
{
    public class RedisInstanceMap : UZeroConsoleEntityTypeConfiguration<RedisInstance>
    {
        public RedisInstanceMap()
        {
            this.ToTable(DbConsts.DbTableName.Caching_RedisInstances);
            this.HasKey(x => x.Id);
        }
    }
}
