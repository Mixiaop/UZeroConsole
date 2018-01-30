using System.Data.SqlClient;
using U.Dapper.Repositories;
using U.Domain.Entities;

namespace UZeroConsole.Dapper
{
    public abstract class UZeroConsoleDapperRepositoryBase<TEntity> : DapperRepositoryBase<TEntity, int> where TEntity : class, IEntity<int>
    {
        protected UZeroConsoleDapperRepositoryBase(UZeroConsoleDapperContextProvider contextProvider) : base(contextProvider) { }

        /// <summary>
        /// 打开连接
        /// </summary>
        /// <returns></returns>
        public SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(Context.GetConnection().ConnectionString);
            connection.Open();
            return connection;
        } 
    }
}
