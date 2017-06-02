using UZeroConsole.Domain.Logging;

namespace UZeroConsole.EntityFramework.Mapping.Logging
{
    public class LogAppMap : UZeroConsoleEntityTypeConfiguration<LogApp>
    {
        public LogAppMap() {
            this.ToTable(DbConsts.DbTableName.Logging_LogApps);
            this.HasKey(x => x.Id);
        }
    }
}
