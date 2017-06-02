using UZeroConsole.Domain.Logging;

namespace UZeroConsole.EntityFramework.Repositories
{
    public class VisitLogRepository : UZeroConsoleRepositoryBase<VisitLog>, IVisitLogRepository
    {
        public VisitLogRepository(UZeroConsoleDbContext databaseProvider) : base(databaseProvider) { }
    }
}
