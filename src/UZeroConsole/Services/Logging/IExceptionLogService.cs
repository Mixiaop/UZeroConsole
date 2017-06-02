using System;
using U.Application.Services;
using U.Application.Services.Dto;
using UZeroConsole.Domain.Logging;

namespace UZeroConsole.Services.Logging
{
    public interface IExceptionLogService : IApplicationService
    {
        void Insert(ExceptionLog log);

        ExceptionLog Get(int id);

        PagedResultDto<ExceptionLog> Search(int appId, string keywords = "", DateTime? from = null, DateTime? to = null, int pageIndex = 1, int pageSize = 20);

        /// <summary>
        /// 清空所有日志
        /// </summary>
        /// <param name="appId">对应的应用</param>
        void ClearAll(int appId);

    }
}
