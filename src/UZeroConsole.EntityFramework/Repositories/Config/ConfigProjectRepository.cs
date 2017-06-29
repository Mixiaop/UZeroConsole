using UZeroConsole.Domain.Config;
using UZeroConsole.Domain.Config.Repositories;

namespace UZeroConsole.EntityFramework.Repositories.Config
{
    public class ConfigProjectRepository : UZeroConsoleRepositoryBase<ConfigProject>, IConfigProjectRepository
    {
        public ConfigProjectRepository(UZeroConsoleDbContext databaseProvider) : base(databaseProvider) { }
    }
}
