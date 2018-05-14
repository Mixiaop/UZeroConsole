using System.Collections.Generic;
using U.Application.Services.Dto;
using UZeroConsole.Domain.Caching;

namespace UZeroConsole.Services.Caching
{
    /// <summary>
    /// 管理Redis服务
    /// 1 Instance contains 12 Database
    /// </summary>
    public interface IRedisService : IApplicationService
    {
        #region Instance
        /// <summary>
        /// 分页返回查询的实例
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        PagedResultDto<RedisInstance> QueryInstances(string keywords = "", int pageIndex = 1, int pageSize = 20);

        /// <summary>
        /// 获取一个实例
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        RedisInstance GetInstance(int instanceId);

        /// <summary>
        /// 更新一个实例
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        StateOutput UpdateInstance(RedisInstance instance);

        /// <summary>
        /// 删除一个实例
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        StateOutput DeleteInstance(int instanceId);
        #endregion

        #region Database
        /// <summary>
        /// 分页返回查询的数据库（Redis一个实例对应12个数据库）
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        PagedResultDto<RedisDatabase> QueryDatabases(int instanceId = 0, int pageIndex = 1, int pageSize = 20);

        /// <summary>
        /// 更新数据库简介
        /// </summary>
        /// <param name="databaseId"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        StateOutput UpdateDatabaseDesc(int databaseId, string description);
        #endregion

        #region Clear
        #endregion
    }
}
