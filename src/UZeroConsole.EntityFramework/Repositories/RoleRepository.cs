using UZeroConsole.Domain;

namespace UZeroConsole.EntityFramework.Repositories
{
    public class RoleRepository : UZeroConsoleRepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(UZeroConsoleDbContext databaseProvider) : base(databaseProvider) { }
    }
}
