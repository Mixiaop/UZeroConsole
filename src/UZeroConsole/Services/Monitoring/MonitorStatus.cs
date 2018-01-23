using U.CodeAnnotations;

namespace UZeroConsole.Services.Monitoring
{
    public enum MonitorStatus
    {
        [EnumAlias("良好")]
        Good = 0,
        [EnumAlias("未知")]
        Unknow = 1,
        [EnumAlias("维修")]
        Maintenance = 2,
        [EnumAlias("警告")]
        Warning = 3,
        [EnumAlias("危急")]
        Critical = 4
    }

    public interface IMonitorStatus {
        MonitorStatus MonitorStatus { get; }
        string MonitorStatusReason { get; }
    }

    public interface IMonitedService : IMonitorStatus { }
}
