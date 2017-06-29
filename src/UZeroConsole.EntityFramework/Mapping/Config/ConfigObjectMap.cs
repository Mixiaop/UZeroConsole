using UZeroConsole.Domain.Config;

namespace UZeroConsole.EntityFramework.Mapping.Config
{
    public class ConfigObjectMap : UZeroConsoleEntityTypeConfiguration<ConfigObject>
    {
        public ConfigObjectMap()
        {
            this.ToTable(DbConsts.DbTableName.Config_ConfigObjects);
            this.HasKey(x => x.Id);

            this.HasRequired(x => x.Project).WithMany().HasForeignKey(x => x.ProjectId);

            this.Ignore(x => x.Attrs);
        }
    }
}
