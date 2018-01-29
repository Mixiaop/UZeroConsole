using U;
using UZeroConsole.Configuration;
using UZeroConsole.Configuration.Monitoring;

namespace UZeroConsole.Monitoring
{
    public class MonitoringSettings : U.Dependency.ISingletonDependency
    {
        public ConsoleSettings Console;
        public SQLSettings SQL;
        private MonitoringSettings() {
            Console = UPrimeEngine.Instance.Resolve<ConsoleSettings>();
            SQL = UPrimeEngine.Instance.Resolve<SQLSettings>();
        }

        private static MonitoringSettings _current;
        public static MonitoringSettings Current => _current ?? (_current = new MonitoringSettings()); 
        
    }
}
