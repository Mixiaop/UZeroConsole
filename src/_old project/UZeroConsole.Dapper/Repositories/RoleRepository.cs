using UZeroConsole.Domain;

namespace UZeroConsole.Dapper.Repositories
{
    public class RoleRepository : UZeroConsoleDapperRepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(UZeroConsoleDapperContextProvider databaseProvider) : base(databaseProvider) { }
    }
}
