using UZeroConsole.Domain;

namespace UZeroConsole.EntityFramework.Repositories
{
    public class AdminRepository : UZeroConsoleRepositoryBase<Admin>, IAdminRepository
    {
        public AdminRepository(UZeroConsoleDbContext databaseProvider) : base(databaseProvider) { }
    }
}
