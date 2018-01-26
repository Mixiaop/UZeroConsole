using System;

namespace UZeroConsole.Monitoring
{
    internal static partial class Current
    {
        public static MonitoringSettings Settings => MonitoringSettings.Current;
        public static readonly Helpers.LocalCache LocalCache = new Helpers.LocalCache();

        public static void LogException(string message, Exception innerException)
        {
            var ex = new Exception(message, innerException);

        }

        public static void LogException(Exception exception, string key = null)
        {
            
        }
    }

    public static class CoreCurrent
    {
        public static Helpers.LocalCache LocalCache => Current.LocalCache;
    }
}
