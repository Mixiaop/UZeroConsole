using UZeroConsole.Domain;
using UZeroConsole.Domain.Repositories;

namespace UZeroConsole.EntityFramework.Repositories
{
    public class TagRepository : UZeroConsoleRepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(UZeroConsoleDbContext databaseProvider) : base(databaseProvider) { }
    }
}
