using UZeroConsole.Domain.Logging;

namespace UZeroConsole.EntityFramework.Mapping.Logging
{
    public class ActionLogMap : UZeroConsoleEntityTypeConfiguration<ActionLog>
    {
        public ActionLogMap()
        {
            this.ToTable(DbConsts.DbTableName.Logging_ActionLogs);
            this.HasKey(x => x.Id);

            this.HasRequired(x => x.App).WithMany().HasForeignKey(x => x.AppId);

            this.Ignore(x=>x.OperateType);
        }
    }
}
