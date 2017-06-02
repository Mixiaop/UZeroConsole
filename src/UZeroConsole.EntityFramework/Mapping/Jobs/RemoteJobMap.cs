using UZeroConsole.Domain.Jobs;

namespace UZeroConsole.EntityFramework.Mapping.Jobs
{
    public class RemoteJobMap : UZeroConsoleEntityTypeConfiguration<RemoteJob>
    {
        public RemoteJobMap()
        {
            this.ToTable(DbConsts.DbTableName.Jobs_RemoteJobs);
            this.HasKey(x => x.Id);

            this.Ignore(x => x.Type);
            this.Ignore(x => x.Opend);
        }
    }
}
