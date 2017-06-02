using UZeroConsole.Domain;

namespace UZeroConsole.EntityFramework.Repositories
{
    public class PermissionRepository : UZeroConsoleRepositoryBase<Permission>, IPermissionRepository
    {
        public PermissionRepository(UZeroConsoleDbContext databaseProvider) : base(databaseProvider) { }
    }
}
