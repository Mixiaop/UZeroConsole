using System;
using System.Linq;
using System.Collections.Generic;
using U.Application.Services.Dto;
using UZeroConsole.Domain.Caching;
using UZeroConsole.Domain.Caching.Repositories;

namespace UZeroConsole.Services.Caching.Impl
{
    public class RedisService : IApplicationService
    {
        private readonly IRedisInstanceRepository _instanceRepository;
        private readonly IRedisDatabaseRepository _databaseRepository;
        public RedisService(IRedisInstanceRepository instanceRepository, IRedisDatabaseRepository databaseRepository) {
            _instanceRepository = instanceRepository;
            _databaseRepository = databaseRepository;
        }

        #region Instance
        /// <summary>
        /// 分页返回查询的实例
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagedResultDto<RedisInstance> QueryInstances(string keywords = "", int pageIndex = 1, int pageSize = 20) {
            var query = _instanceRepository.GetAll();
            if (keywords.IsNotNullOrEmpty()) {
                query = query.Where(x => x.Name.Contains(keywords));
            }

            var list = query.OrderByDescending(x => x.CreationTime)
                            .Skip((pageIndex - 1)).Take(pageSize).ToList();

            var count = query.Count();

            return new PagedResultDto<RedisInstance>(count, list);
        }

        /// <summary>
        /// 获取一个实例
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public RedisInstance GetInstance(int instanceId) {
            if (instanceId > 0)
            {
                return _instanceRepository.Get(instanceId);
            }
            else
                return new RedisInstance();
        }

        /// <summary>
        /// 更新一个实例
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public StateOutput UpdateInstance(RedisInstance instance) {
            StateOutput res = new StateOutput();
            try
            {

            }
            catch (Exception ex) {
                res.AddError(ex.Message);
            }
            return res;
        }

        /// <summary>
        /// 删除一个实例
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public StateOutput DeleteInstance(int instanceId) {
            StateOutput res = new StateOutput();
            try
            {

            }
            catch (Exception ex) {
                res.AddError(ex.Message);
            }
            return res;
        }
        #endregion

        #region Database
        /// <summary>
        /// 分页返回查询的数据库（Redis一个实例对应12个数据库）
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagedResultDto<RedisDatabase> QueryDatabases(int instanceId = 0, int pageIndex = 1, int pageSize = 20) {

            return new PagedResultDto<RedisDatabase>(0, null);
        }

        /// <summary>
        /// 更新数据库简介
        /// </summary>
        /// <param name="databaseId"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public StateOutput UpdateDatabaseDesc(int databaseId, string description) {
            StateOutput res = new StateOutput();

            return res;
        }
        #endregion

        #region Clear
        #endregion
    }
}
