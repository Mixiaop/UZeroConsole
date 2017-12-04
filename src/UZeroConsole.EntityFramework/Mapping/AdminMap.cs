using UZeroConsole.Domain;

namespace UZeroConsole.EntityFramework.Mapping
{
    public partial class AdminMap : UZeroConsoleEntityTypeConfiguration<Admin>
    {
        public AdminMap()
        {
            this.ToTable(DbConsts.DbTableName.Admins);
            this.HasKey(x => x.Id);

            this.HasRequired(x => x.Role).WithMany().HasForeignKey(x => x.RoleId);

            this.HasMany(x => x.Roles).WithMany()
                                    .Map(m =>
                                    {
                                        m.ToTable(DbConsts.DbTableName.Admin_Roles_Mapping);
                                        m.MapLeftKey("AdminId");
                                        m.MapRightKey("RoleId");
                                    });

            this.Ignore(x => x.RoleIds);
        }
    }
}
