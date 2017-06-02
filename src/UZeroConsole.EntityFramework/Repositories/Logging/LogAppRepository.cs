using UZeroConsole.Domain.Logging;

namespace UZeroConsole.EntityFramework.Repositories
{
    public class LogAppRepository : UZeroConsoleRepositoryBase<LogApp>, ILogAppRepository
    {
        public LogAppRepository(UZeroConsoleDbContext databaseProvider) : base(databaseProvider) { }
    }
}
