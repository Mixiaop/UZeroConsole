using System;
using System.Collections.Generic;
using System.Linq;

namespace UZeroConsole.Monitoring
{
    public static partial class ExtensionMethods
    {
        public static IEnumerable<T> WithIssues<T>(this IEnumerable<T> items) where T : IMonitorStatus =>
            items.Where(i => i.MonitorStatus != MonitorStatus.Good);

        public static string GetReasonSummary(this IEnumerable<IMonitorStatus> items) =>
            string.Join(", ", items.WithIssues().Select(i => i.MonitorStatusReason));

        public static MonitorStatus GetWorstStatus(this IEnumerable<IMonitorStatus> ims, string cacheKey = null, TimeSpan? duration = null)
        {
            duration = duration ?? 5.Seconds();
            if (ims == null)
                return MonitorStatus.Unknown;
            MonitorStatus? result = null;
            if (cacheKey.IsNotNullOrEmpty())
                result = Current.LocalCache.Get<MonitorStatus?>(cacheKey);
            if (result == null)
            {
                result = GetWorstStatus(ims.Select(i => i.MonitorStatus));
                if (cacheKey.IsNotNullOrEmpty())
                    Current.LocalCache.Set(cacheKey, result, duration);
            }
            return result.Value;
        }

        public static MonitorStatus GetWorstStatus(this IEnumerable<MonitorStatus> ims) => ims.OrderByDescending(i => i).FirstOrDefault();

        public static long ToEpochTime(this DateTime dt, bool toMilliseconds = false)
        {
            var seconds = (long)(dt - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
            return toMilliseconds ? seconds * 1000 : seconds;
        }

        public static T SafeData<T>(this Cache<T> cache, bool emptyIfMissing = false) where T : class, new() =>
           cache?.Data ?? (emptyIfMissing ? new T() : null);
    }
}
