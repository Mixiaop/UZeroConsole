using UZeroConsole.Domain.Caching;

namespace UZeroConsole.EntityFramework.Mapping.Caching
{
    public class RedisDatabaseMap : UZeroConsoleEntityTypeConfiguration<RedisDatabase>
    {
        public RedisDatabaseMap()
        {
            this.ToTable(DbConsts.DbTableName.Caching_RedisDatabases);
            this.HasKey(x => x.Id);
        }
    }
}
