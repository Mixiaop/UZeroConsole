using U.Domain.Repositories;

namespace UZeroConsole.Domain.Logging
{
    public interface IExceptionLogRepository : IRepository<ExceptionLog>
    {
        /// <summary>
        /// 清空所有日志
        /// </summary>
        /// <param name="appId"></param>
        void ClearAll(int appId);
    }
}
