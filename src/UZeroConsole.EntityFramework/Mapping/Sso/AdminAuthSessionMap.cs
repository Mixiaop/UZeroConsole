using UZeroConsole.Domain.Sso;

namespace UZeroConsole.EntityFramework.Mapping.Sso
{
    public partial class AdminAuthSessionMap : UZeroConsoleEntityTypeConfiguration<AdminAuthSession>
    {
        public AdminAuthSessionMap()
        {
            this.ToTable(DbConsts.DbTableName.Sso_AdminAuthSessions);
            this.HasKey(x => x.Id);

            this.HasRequired(x => x.Admin).WithMany().HasForeignKey(x => x.AdminId);
        }
    }
}
