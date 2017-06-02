using UZeroConsole.Domain;

namespace UZeroConsole.EntityFramework.Mapping
{
    public partial class AdminMap : UZeroConsoleEntityTypeConfiguration<Admin>
    {
        public AdminMap() {
            this.ToTable(DbConsts.DbTableName.Admins);
            this.HasKey(x => x.Id);

            this.HasRequired(x => x.Role).WithMany().HasForeignKey(x => x.RoleId);
        }
    }
}
