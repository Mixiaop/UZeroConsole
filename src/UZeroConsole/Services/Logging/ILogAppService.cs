using U.Application.Services;
using U.Application.Services.Dto;
using UZeroConsole.Domain.Logging;

namespace UZeroConsole.Services.Logging
{
    /// <summary>
    /// 日志应用服务
    /// 操作使用日志模块的应用说明及密钥
    /// </summary>
    public interface ILogAppService : IApplicationService
    {
        PagedResultDto<LogApp> Search(string keywords, int pageIndex = 1, int pageSize = 20);

        LogApp Get(int appId);

        LogApp Get(string key);

        int Create(string name, string description, string key, bool isTests = false);

        void Update(LogApp app);

        void Delete(int appId);

        void Delete(LogApp app);

    }
}
