using UZeroConsole.Domain.Caching;
using UZeroConsole.Domain.Caching.Repositories;

namespace UZeroConsole.EntityFramework.Repositories.Caching
{
    public class RedisDatabaseRepository : UZeroConsoleRepositoryBase<RedisDatabase>, IRedisDatabaseRepository
    {
        public RedisDatabaseRepository(UZeroConsoleDbContext databaseProvider) : base(databaseProvider) { }
    }
}
