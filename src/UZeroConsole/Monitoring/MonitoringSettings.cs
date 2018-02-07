using U;
using UZeroConsole.Configuration.Monitoring;

namespace UZeroConsole.Monitoring
{
    public class MonitoringSettings : U.Dependency.ISingletonDependency
    {
        public SQLSettings SQL;
        public RedisSettings Redis;
        private MonitoringSettings() {
            SQL = UPrimeEngine.Instance.Resolve<SQLSettings>();
            Redis = UPrimeEngine.Instance.Resolve<RedisSettings>();
        }

        private static MonitoringSettings _current;
        public static MonitoringSettings Current => _current ?? (_current = new MonitoringSettings()); 
        
    }
}
