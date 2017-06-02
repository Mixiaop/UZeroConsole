using System.Linq;
using U.Application.Services;
using U.Application.Services.Dto;
using UZeroConsole.Domain.Logging;

namespace UZeroConsole.Services.Logging
{
    public class LogAppService : ILogAppService
    {
        private readonly ILogAppRepository _appRepository;
        public LogAppService(ILogAppRepository appRepository) {
            _appRepository = appRepository;
        }

        public PagedResultDto<LogApp> Search(string keywords, int pageIndex = 1, int pageSize = 20) {
            var query = _appRepository.GetAll();
            if (keywords.IsNotNullOrEmpty()) {
                query = query.Where(x => x.Name.Contains(keywords) || x.Description.Contains(keywords));
            }
            query = query
                         .OrderBy(x => x.IsTests)
                         .ThenByDescending(x => x.CreationTime);

            var count = query.Count();
            var list = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return new PagedResultDto<LogApp>(count, list);
        }

        public LogApp Get(int appId) {
            return _appRepository.Get(appId);
        }

        public LogApp Get(string key) {
            return _appRepository.FirstOrDefault(x => x.Key == key.Trim());
        }

        public int Create(string name, string description, string key, bool isTests = false)
        {
            LogApp app = new LogApp();
            app.Name = name;
            app.Description = description;
            app.Key = key;
            app.IsTests = isTests;

            return _appRepository.InsertAndGetId(app);
        }

        public void Update(LogApp app) {
            _appRepository.Update(app);
        }

        public void Delete(int appId) {
            _appRepository.Delete(appId);
        }

        public void Delete(LogApp app) {
            _appRepository.Delete(app);
        }
    }
}
