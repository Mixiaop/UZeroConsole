using System;
using System.Collections.Generic;
using U.Settings;

namespace UZeroConsole.Configuration.Monitoring
{
    [USettingsPathArribute("ClientHostSettings.json", "/Config/UZeroConsole/Monitoring/")]
    public class ClientHostSettings : USettings<ClientHostSettings>
    {
        public List<HostInfo> Hosts { get; set; }

        public class HostInfo
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Ip { get; set; }
            public string LastUpdate { get; set; }

            public float CPUUsagePercent { get; set; }
            public float RAMUsedPercent { get; set; }

            public List<DiskInfo> Disks { get; set; }

            public float WebService_CurrentConnections { get; set; }
        }

        public class DiskInfo
        {
            public string Name { get; set; }
            public float TotalSize { get; set; }
            public float FreeTotalSpace { get; set; }
            public float UsedSpace { get; set; }
        }
    }
}
