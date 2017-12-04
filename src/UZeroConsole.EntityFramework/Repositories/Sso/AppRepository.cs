using UZeroConsole.Domain.Sso;
using UZeroConsole.Domain.Sso.Repositories;

namespace UZeroConsole.EntityFramework.Repositories.Sso
{
    public class AppRepository : UZeroConsoleRepositoryBase<App>, IAppRepository
    {
        public AppRepository(UZeroConsoleDbContext databaseProvider) : base(databaseProvider) { }
    }
}
