using UZeroConsole.Domain.Jobs;

namespace UZeroConsole.EntityFramework.Repositories.Jobs
{
    public class RemoteJobRepository : UZeroConsoleRepositoryBase<RemoteJob>, IRemoteJobRepository
    {
        public RemoteJobRepository(UZeroConsoleDbContext databaseProvider) : base(databaseProvider) { }
    }
}
