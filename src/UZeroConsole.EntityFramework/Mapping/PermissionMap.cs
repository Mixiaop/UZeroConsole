using UZeroConsole.Domain;

namespace UZeroConsole.EntityFramework.Mapping
{
    public class PermissionMap : UZeroConsoleEntityTypeConfiguration<Permission>
    {
        public PermissionMap()
        {
            this.ToTable(DbConsts.DbTableName.Permissions);
            this.HasKey(x => x.Id);
        }
    }
}
