using UZeroConsole.Domain.Sso;
using UZeroConsole.Domain.Sso.Repositories;

namespace UZeroConsole.EntityFramework.Repositories.Sso
{
    public class AdminAuthSessionRepository : UZeroConsoleRepositoryBase<AdminAuthSession>, IAdminAuthSessionRepository
    {
        public AdminAuthSessionRepository(UZeroConsoleDbContext databaseProvider) : base(databaseProvider) { }
    }
}
