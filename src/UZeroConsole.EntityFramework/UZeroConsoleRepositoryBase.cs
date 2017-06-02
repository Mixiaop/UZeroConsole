using U.Domain.Entities;
using U.EntityFramework.Repositories;

namespace UZeroConsole.EntityFramework
{
    public abstract class UZeroConsoleRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<UZeroConsoleDbContext, TEntity, TPrimaryKey>
       where TEntity : class, IEntity<TPrimaryKey>
    {
        protected UZeroConsoleRepositoryBase(UZeroConsoleDbContext dbContext)
            : base(dbContext, false)
        {

        }
    }

    public abstract class UZeroConsoleRepositoryBase<TEntity> : EfRepositoryBase<UZeroConsoleDbContext, TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected UZeroConsoleRepositoryBase(UZeroConsoleDbContext dbContext)
            : base(dbContext, false)
        {

        }
    }
}
