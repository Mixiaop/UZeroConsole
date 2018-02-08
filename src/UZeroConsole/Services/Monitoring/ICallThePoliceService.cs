using U.Application.Services.Dto;

namespace UZeroConsole.Services.Monitoring
{
    /// <summary>
    /// 监控报警服务（检查有问题就报警）
    /// </summary>
    public interface ICallThePoliceService : IApplicationService
    {
        /// <summary>
        /// 检查如果指标超出则通知
        /// </summary>
        /// <returns></returns>
        StateOutput CheckOrCall();
    }
}
