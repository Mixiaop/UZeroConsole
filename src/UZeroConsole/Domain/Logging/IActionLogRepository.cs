using U.Domain.Repositories;

namespace UZeroConsole.Domain.Logging
{
    public interface IActionLogRepository : IRepository<ActionLog>
    {
        /// <summary>
        /// 清空所有日志
        /// </summary>
        /// <param name="appId"></param>
        void ClearAll(int appId);
    }
}
