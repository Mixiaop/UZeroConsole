using System.Data;
using System.Data.SqlClient;
using U.Dapper;
using U.Dapper.Sql;

namespace UZeroConsole.Dapper
{
    public class UZeroConsoleDapperContextProvider : IDapperContextProvider
    {
        private readonly UZeroConsoleDapperConfiguration _configuration;
        public IDapperImplementor Dapper
        {
            get;
            private set;
        }

        public UZeroConsoleDapperContextProvider(UZeroConsoleDapperConfiguration configuration)
        {
            _configuration = configuration;
            var sqlGenerator = new SqlGeneratorImpl(configuration);
            Dapper = new DapperImplementor(sqlGenerator);
        }

        public IDbConnection GetConnection(bool readOnly = false)
        {
            SqlConnection conn = null;
            if (_configuration.OpenedReadAndWrite && readOnly)
            {
                conn = new SqlConnection(_configuration.ReadSqlConnectionString);
            }
            else
                conn = new SqlConnection(_configuration.SqlConnectionString);

            return conn;
        }
    }
}
