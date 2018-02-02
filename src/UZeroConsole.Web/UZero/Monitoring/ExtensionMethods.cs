using UZeroConsole.Monitoring;

namespace UZeroConsole.Web.UZero.Monitoring
{
    public static partial class ExtensionMethods
    {
        public static string ToPollSpan(this Cache cache, bool lastSuccess = false, bool mini = true)
        {
            if (cache?.LastPoll == null)
                return MonitorStatus.Warning.Span("Unknown", "暂无数据");

            if (lastSuccess)
                return mini ? cache.LastSuccess?.ToRelativeTime() : cache.LastSuccess?.ToRelativeTime();

            var lf = cache.LastPoll;
            if (lf == null)
                return MonitorStatus.Warning.Span("Unknown", "暂无数据");

            var dateToUse = cache.LastSuccess ?? cache.LastPoll;
            if (!cache.LastPollSuccessful)
            {
                return MonitorStatus.Warning.Span(mini ? dateToUse?.ToRelativeTime() : dateToUse?.ToRelativeTime(),
                   $"最后轮询: {lf.Value.ToString("yyyy-MM-dd HH:mm:ss")} ({lf.Value.ToRelativeTime()})\nError: {cache.ErrorMessage}");
            }

            return mini ? lf.Value.ToRelativeTime() : lf.Value.ToRelativeTime();
        }

        public static string Span(this MonitorStatus status, string title, string summary)
        {
            return string.Format("<span>{0}: {1}<span>", title, summary);
        }

        public static string IconSpan(this MonitorStatus status)
        {
            switch (status)
            {
                case MonitorStatus.Good:
                    return "<i class=\"fa fa-circle text-success\"></i>";
                case MonitorStatus.Warning:
                    return "<i class=\"fa fa-circle text-warning\"></i>";
                case MonitorStatus.Maintenance:
                    return "<i class=\"fa fa-circle text-danger\"></i>";
                case MonitorStatus.Critical:
                    return "<i class=\"fa fa-circle text-danger\"></i>";
                default:
                    return "<i class=\"fa fa-circle\"></i>";

            }

        }
    }
}