using UZeroConsole.Domain;

namespace UZeroConsole.EntityFramework.Repositories
{

    public class RolePermissionRepository : UZeroConsoleRepositoryBase<RolePermission>, IRolePermissionRepository
    {
        public RolePermissionRepository(UZeroConsoleDbContext databaseProvider) : base(databaseProvider) { }
    }
}
