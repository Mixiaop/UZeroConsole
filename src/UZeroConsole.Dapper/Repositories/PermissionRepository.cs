using UZeroConsole.Domain;

namespace UZeroConsole.Dapper.Repositories
{
    public class PermissionRepository : UZeroConsoleDapperRepositoryBase<Permission>, IPermissionRepository
    {
        public PermissionRepository(UZeroConsoleDapperContextProvider databaseProvider) : base(databaseProvider) { }
    }
}
