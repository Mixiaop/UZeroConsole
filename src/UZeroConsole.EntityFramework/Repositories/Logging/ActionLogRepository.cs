using UZeroConsole.Domain.Logging;

namespace UZeroConsole.EntityFramework.Repositories
{
    public class ActionLogRepository : UZeroConsoleRepositoryBase<ActionLog>, IActionLogRepository
    {
        public ActionLogRepository(UZeroConsoleDbContext databaseProvider) : base(databaseProvider) { }

        public void ClearAll(int appId)
        {
            if (appId > 0)
                this.Context.ExecuteSqlCommand(string.Format("DELETE FROM [{0}] WHERE [AppId]={1}", DbConsts.DbTableName.Logging_ActionLogs, appId));
        }
    }
}
