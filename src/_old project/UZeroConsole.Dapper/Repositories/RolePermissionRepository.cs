using UZeroConsole.Domain;

namespace UZeroConsole.Dapper.Repositories
{
    public class RolePermissionRepository : UZeroConsoleDapperRepositoryBase<RolePermission>, IRolePermissionRepository
    {
        public RolePermissionRepository(UZeroConsoleDapperContextProvider databaseProvider) : base(databaseProvider) { }
    }
}
