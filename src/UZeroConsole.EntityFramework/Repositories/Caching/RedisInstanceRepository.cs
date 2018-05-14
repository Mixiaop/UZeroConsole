using UZeroConsole.Domain.Caching;
using UZeroConsole.Domain.Caching.Repositories;

namespace UZeroConsole.EntityFramework.Repositories.Caching
{
    public class RedisInstanceRepository : UZeroConsoleRepositoryBase<RedisInstance>, IRedisInstanceRepository
    {
        public RedisInstanceRepository(UZeroConsoleDbContext databaseProvider) : base(databaseProvider) { }
    }
}