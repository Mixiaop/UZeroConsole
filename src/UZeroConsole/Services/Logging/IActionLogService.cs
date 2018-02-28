using System;
using System.Collections.Generic;
using U.Application.Services;
using U.Application.Services.Dto;
using UZeroConsole.Domain.Logging;
using UZeroConsole.Services.Logging.Dto;

namespace UZeroConsole.Services.Logging
{
    public interface IActionLogService : IApplicationService
    {
        void Insert(ActionLog log);

        ActionLog Get(int id);

        PagedResultDto<ActionLogDto> Search(int appId, string moduleName = "", string operatorId = "", string keywords = "", DateTime? from = null, DateTime? to = null, int pageIndex = 1, int pageSize = 20);

        /// <summary>
        /// 获取某个操作者的最常用的操作（次数大到小排序）
        /// </summary>
        /// <param name="appId">应用标识</param>
        /// <param name="operatorId">操作者标识</param>
        /// <param name="topCount">top几</param>
        /// <returns></returns>
        IList<ActionLogTopDto> GetTopLogs(int appId, string operatorId, int topCount = 10);

        /// <summary>
        /// 清空所有日志
        /// </summary>
        /// <param name="appId">对应的应用</param>
        void ClearAll(int appId);

        #region Modules
        bool ExistsModule(int appId, string moduleName);

        void InsertModule(ActionModule module);

        IList<ActionModule> GetAllModules(int appId);
        #endregion
    }
}
