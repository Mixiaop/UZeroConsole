using UZeroConsole.Domain.Logging;

namespace UZeroConsole.EntityFramework.Repositories
{
    public class ActionModuleRepository : UZeroConsoleRepositoryBase<ActionModule>, IActionModuleRepository
    {
        public ActionModuleRepository(UZeroConsoleDbContext databaseProvider) : base(databaseProvider) { }
    }
}
