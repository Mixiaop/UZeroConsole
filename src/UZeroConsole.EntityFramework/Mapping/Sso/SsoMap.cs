using UZeroConsole.Domain.Sso;

namespace UZeroConsole.EntityFramework.Mapping.Sso
{
    public partial class SsoMap : UZeroConsoleEntityTypeConfiguration<App>
    {
        public SsoMap()
        {
            this.ToTable(DbConsts.DbTableName.Sso_Apps);
            this.HasKey(x => x.Id);
        }
    }
}
