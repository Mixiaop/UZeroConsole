using UZeroConsole.Domain.Config;
using UZeroConsole.Domain.Config.Repositories;

namespace UZeroConsole.EntityFramework.Repositories.Config
{
    public class ConfigAttrRepository : UZeroConsoleRepositoryBase<ConfigAttr>, IConfigAttrRepository
    {
        public ConfigAttrRepository(UZeroConsoleDbContext databaseProvider) : base(databaseProvider) { }
    }
}
