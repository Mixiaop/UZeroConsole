using UZeroConsole.Domain.Config;

namespace UZeroConsole.EntityFramework.Mapping.Config
{
    public class ConfigProjectMap : UZeroConsoleEntityTypeConfiguration<ConfigProject>
    {
        public ConfigProjectMap()
        {
            this.ToTable(DbConsts.DbTableName.Config_ConfigProjects);
            this.HasKey(x => x.Id);
        }
    }
}
