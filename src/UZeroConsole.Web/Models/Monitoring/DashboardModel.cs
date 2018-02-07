using System.Collections.Generic;
using UZeroConsole.Configuration.Monitoring;
using UZeroConsole.Monitoring.Redis;
using UZeroConsole.Monitoring.SQL;

namespace UZeroConsole.Web.Models.Monitoring
{
    public class DashboardModel
    {
        public int Refresh { get; set; } = 5;
        public List<ClientHostSettings.HostInfo> Hosts { get; set; }

        public List<SQLInstance> StandaloneInstances { get; set; }

        public List<RedisInstance> RedisInstances { get; set; }

    }
}