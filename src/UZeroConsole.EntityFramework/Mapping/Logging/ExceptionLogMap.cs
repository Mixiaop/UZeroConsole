using UZeroConsole.Domain.Logging;

namespace UZeroConsole.EntityFramework.Mapping.Logging
{
    public class ExceptionLogMap : UZeroConsoleEntityTypeConfiguration<ExceptionLog>
    {
        public ExceptionLogMap()
        {
            this.ToTable(DbConsts.DbTableName.Logging_ExceptionLogs);
            this.HasKey(x => x.Id);

            this.HasRequired(x => x.App).WithMany().HasForeignKey(x => x.AppId);
        }
    }
}
