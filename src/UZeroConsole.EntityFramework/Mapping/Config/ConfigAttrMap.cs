using UZeroConsole.Domain.Config;

namespace UZeroConsole.EntityFramework.Mapping.Config
{
    public class ConfigAttrMap : UZeroConsoleEntityTypeConfiguration<ConfigAttr>
    {
        public ConfigAttrMap()
        {
            this.ToTable(DbConsts.DbTableName.Config_ConfigAttrs);
            this.HasKey(x => x.Id);

            this.HasRequired(x => x.Project).WithMany().HasForeignKey(x => x.ProjectId);
            this.HasRequired(x => x.Object).WithMany().HasForeignKey(x => x.ObjectId);
        }
    }
}
