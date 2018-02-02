using System;
using U;
using U.Logging;
using UZeroConsole.Monitoring;
using UZeroConsole.Configuration;

namespace UZeroConsole
{
    internal static partial class Current
    {
        private static ConsoleSettings _consoleSettings = UPrimeEngine.Instance.Resolve<ConsoleSettings>();

        public static ConsoleSettings ConsoleSettings => _consoleSettings;
        public static MonitoringSettings MonitoringSettings => MonitoringSettings.Current;
        public static readonly Helpers.LocalCache LocalCache = new Helpers.LocalCache();

        public static void LogException(string message, Exception innerException)
        {
            var ex = new Exception(message, innerException);
            LogException(ex);
        }

        public static void LogException(Exception exception, string key = null)
        {
            LogHelper.Logger.Error(exception, exception.Message);
        }
    }

    public static class CoreCurrent
    {
        public static Helpers.LocalCache LocalCache => Current.LocalCache;
    }
}
