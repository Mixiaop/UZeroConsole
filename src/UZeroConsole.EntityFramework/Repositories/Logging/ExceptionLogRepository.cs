using UZeroConsole.Domain.Logging;

namespace UZeroConsole.EntityFramework.Repositories
{
    public class ExceptionLogRepository : UZeroConsoleRepositoryBase<ExceptionLog>, IExceptionLogRepository
    {
        public ExceptionLogRepository(UZeroConsoleDbContext databaseProvider) : base(databaseProvider) { }

        public void ClearAll(int appId)
        {
            if (appId > 0)
                this.Context.ExecuteSqlCommand(string.Format("DELETE FROM [{0}] WHERE [AppId]={1}", DbConsts.DbTableName.Logging_ExceptionLogs, appId));
        }
    }
}
