using System.Collections.Generic;
using System.Net;
using StackExchange.Redis;
using UZeroConsole.Configuration.Monitoring;
using UZeroConsole.Helpers;
namespace UZeroConsole.Monitoring.Redis
{
    public partial class RedisConnectionInfo
    {
        public string Name => Settings.Name;
        public string Host { get; internal set; }
        public int Port => Settings.Port;
        public string Password => Settings.Password;
        public RedisFeatures Features { get; internal set; }
        internal RedisSettings.Instance Settings { get; set; }

        internal RedisConnectionInfo(string host, RedisSettings.Instance settings)
        {
            Settings = settings;
            Host = host;
        }

        public List<IPAddress> IPAddresses => AppCache.GetHostAddresses(Host);

        public override string ToString() => $"{Name} ({Host}:{Port})";
    }
}
