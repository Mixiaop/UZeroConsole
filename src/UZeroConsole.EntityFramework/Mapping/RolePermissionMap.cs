using UZeroConsole.Domain;

namespace UZeroConsole.EntityFramework.Mapping
{
    public class RolePermissionMap: UZeroConsoleEntityTypeConfiguration<RolePermission>
    {
        public RolePermissionMap()
        {
            this.ToTable(DbConsts.DbTableName.RolePermissions);
            this.HasKey(x => x.Id);

            this.HasRequired(x => x.Role).WithMany().HasForeignKey(x => x.RoleId);
            this.HasRequired(x => x.Permission).WithMany().HasForeignKey(x => x.PermissionId);
        }
    }
}
