using UZeroConsole.Domain.Logging;

namespace UZeroConsole.EntityFramework.Mapping.Logging
{
    public class VisitLogMap : UZeroConsoleEntityTypeConfiguration<VisitLog>
    {
        public VisitLogMap()
        {
            this.ToTable(DbConsts.DbTableName.Logging_VisitLogs);
            this.HasKey(x => x.Id);

            this.HasRequired(x => x.App).WithMany().HasForeignKey(x => x.AppId);
        }
    }
}
