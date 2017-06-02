using System;
using System.Linq;
using U.Application.Services.Dto;
using UZeroConsole.Domain.Logging;

namespace UZeroConsole.Services.Logging
{
    public class ExceptionLogService : IExceptionLogService
    {
        private readonly IExceptionLogRepository _logRepository;
        public ExceptionLogService(IExceptionLogRepository logRepository) {
            _logRepository = logRepository;
        }

        public void Insert(ExceptionLog log) {
            _logRepository.Insert(log);
        }

        public ExceptionLog Get(int id) {
            return _logRepository.Get(id);
        }

        public PagedResultDto<ExceptionLog> Search(int appId, string keywords = "", DateTime? from = null, DateTime? to = null, int pageIndex = 1, int pageSize = 20)
        {
            var query = _logRepository.GetAll()
                                      .Where(x => x.AppId == appId);
            if (keywords.IsNotNullOrEmpty()) {
                query = query.Where(x => x.App.Name.Contains(keywords) || x.ShortMessage.Contains(keywords));
            }

            if (from.HasValue)
                query = query.Where(x => x.CreationTime >= from);

            if (to.HasValue)
                query = query.Where(x => x.CreationTime <= to);

            query = query.OrderByDescending(x => x.CreationTime);

            var count = query.Count();

            var list = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return new PagedResultDto<ExceptionLog>(count, list);
        }

        /// <summary>
        /// 清空所有日志
        /// </summary>
        /// <param name="appId">对应的应用</param>
        public void ClearAll(int appId) {
            _logRepository.ClearAll(appId);
        }
    }
}
