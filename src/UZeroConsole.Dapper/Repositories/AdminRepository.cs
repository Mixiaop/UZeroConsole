using UZeroConsole.Domain;

namespace UZeroConsole.Dapper.Repositories
{
    public class AdminRepository : UZeroConsoleDapperRepositoryBase<Admin>, IAdminRepository
    {
        public AdminRepository(UZeroConsoleDapperContextProvider databaseProvider) : base(databaseProvider) { }
    }
}
