using System;
using System.Linq;
using System.Collections.Generic;
using UPrime.AutoMapper;
using U.Application.Services.Dto;
using UZeroConsole.Domain.Logging;
using UZeroConsole.Services.Logging.Dto;

namespace UZeroConsole.Services.Logging
{
    public class ActionLogService : IActionLogService
    {
        private readonly IActionLogRepository _logRepository;
        private readonly IActionModuleRepository _moduleRepository;
        public ActionLogService(IActionLogRepository logRepository, IActionModuleRepository moduleRepository)
        {
            _logRepository = logRepository;
            _moduleRepository = moduleRepository;
        }

        public void Insert(ActionLog log)
        {
            if (log.ModuleName.IsNotNullOrEmpty())
            {
                if (!ExistsModule(log.AppId, log.ModuleName))
                {
                    ActionModule module = new ActionModule();
                    module.AppId = log.AppId;
                    module.ModuleName = log.ModuleName;
                    InsertModule(module);
                }
            }

            _logRepository.Insert(log);
        }

        public ActionLog Get(int id)
        {
            return _logRepository.Get(id);
        }

        public PagedResultDto<ActionLogDto> Search(int appId, string moduleName = "", string operatorId = "", string keywords = "", DateTime? from = null, DateTime? to = null, int pageIndex = 1, int pageSize = 20)
        {
            var query = _logRepository.GetAll()
                                      .Where(x => x.AppId == appId);

            if (moduleName.IsNotNullOrEmpty())
            {
                query = query.Where(x => x.ModuleName == moduleName);
            }

            if (operatorId.IsNotNullOrEmpty())
            {
                query = query.Where(x => x.OperatorId == operatorId);
            }

            if (keywords.IsNotNullOrEmpty())
            {
                query = query.Where(x => x.Operator.Contains(keywords) || x.ShortMessage.Contains(keywords));
            }

            if (from.HasValue)
                query = query.Where(x => x.CreationTime >= from);

            if (to.HasValue)
                query = query.Where(x => x.CreationTime <= to);

            query = query.OrderByDescending(x => x.CreationTime);

            var count = query.Count();

            var list = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PagedResultDto<ActionLogDto>(count, list.MapTo<List<ActionLogDto>>());
        }

        public IList<ActionLogTopDto> GetTopLogs(int appId, string operatorId, int topCount = 10)
        {
            operatorId = operatorId.Trim();
            var query = _logRepository.GetAll().Where(x => x.OperatorId == operatorId && x.AppId == appId).GroupBy(x => x.ShortMessage)
                                               .Select(x => new { message = x.Key, count = x.Count() })
                                               .OrderByDescending(x => x.count)
                                               .Take(topCount);

            IList<ActionLogTopDto> result = new List<ActionLogTopDto>();
            var list = query.ToList();
            if (list != null)
            {
                foreach (var info in list)
                {
                    result.Add(new ActionLogTopDto() { ShortMessage = info.message, Count = info.count });
                }
            }

            return result;
        }

        public void ClearAll(int appId)
        {
            _logRepository.ClearAll(appId);
        }

        #region Modules
        public bool ExistsModule(int appId, string moduleName)
        {
            moduleName = moduleName.Trim();
            return _moduleRepository.Count(x => x.AppId == appId && x.ModuleName == moduleName) > 0;
        }

        public void InsertModule(ActionModule module)
        {
            if (module.ModuleName.IsNotNullOrEmpty())
            {
                _moduleRepository.Insert(module);
            }
        }

        public IList<ActionModule> GetAllModules(int appId)
        {
            return _moduleRepository.GetAll().Where(x => x.AppId == appId).OrderBy(x => x.Id).ToList();
        }
        #endregion
    }
}
