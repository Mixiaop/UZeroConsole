using U.Dapper.Startup.Configuration;
using UZeroConsole.Configuration;

namespace UZeroConsole.Dapper
{
    public class UZeroConsoleDapperConfiguration : DapperConfigurationBase
    {
        public UZeroConsoleDapperConfiguration(DatabaseSettings settings)
            : base()
        {
            OpenedReadAndWrite = true;
            SqlConnectionString = settings.SqlConnectionString;
            ReadSqlConnectionString = settings.ReadonlySqlConnectionString;
        }
    }
}
