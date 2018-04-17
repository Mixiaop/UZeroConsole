using UZeroConsole.Domain.Jobs;
using UZeroConsole.Domain.Jobs.Repositories;

namespace UZeroConsole.EntityFramework.Repositories.Jobs
{
    public class RemoteJobRepository : UZeroConsoleRepositoryBase<RemoteJob>, IRemoteJobRepository
    {
        public RemoteJobRepository(UZeroConsoleDbContext databaseProvider) : base(databaseProvider) { }
    }
}
