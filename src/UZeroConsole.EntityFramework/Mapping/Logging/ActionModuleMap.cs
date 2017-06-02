using UZeroConsole.Domain.Logging;

namespace UZeroConsole.EntityFramework.Mapping.Logging
{
    public class ActionModuleMap : UZeroConsoleEntityTypeConfiguration<ActionModule>
    {
        public ActionModuleMap()
        {
            this.ToTable(DbConsts.DbTableName.Logging_ActionModules);
            this.HasKey(x => x.Id);

            this.HasRequired(x => x.App).WithMany().HasForeignKey(x => x.AppId);
        }
    }
}
