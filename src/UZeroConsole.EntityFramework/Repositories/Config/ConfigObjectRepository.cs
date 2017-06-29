using UZeroConsole.Domain.Config;
using UZeroConsole.Domain.Config.Repositories;

namespace UZeroConsole.EntityFramework.Repositories.Config
{
    public class ConfigObjectRepository : UZeroConsoleRepositoryBase<ConfigObject>, IConfigObjectRepository
    {
        public ConfigObjectRepository(UZeroConsoleDbContext databaseProvider) : base(databaseProvider) { }
    }
}
