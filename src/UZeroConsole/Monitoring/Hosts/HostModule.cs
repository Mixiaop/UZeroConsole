using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using U;
using U.Logging;
using U.Settings;
using UZeroConsole.Configuration.Monitoring;

namespace UZeroConsole.Monitoring.Hosts
{
    public class HostModule : StatusModule
    {
        public static ClientHostSettings Settings = UPrimeEngine.Instance.Resolve<ClientHostSettings>();

        /// <summary>
        /// 接收UZeroConsole.WinServices.PerformanceSender发送的数据，存储到配置里
        /// </summary>
        /// <param name="clientInfo"></param>
        public static void Receive(string clientInfo)
        {
            if (clientInfo.IsNotNullOrEmpty())
            {
                var settings = UPrimeEngine.Instance.Resolve<ClientHostSettings>();
                var settingsManager = UPrimeEngine.Instance.Resolve<ISettingsManager>();

                var jsonObj = JsonConvert.DeserializeObject(clientInfo);
                var client = JsonConvert.DeserializeObject<HostJsonInfo>(jsonObj.ToString());



                if (settings.Hosts == null)
                    settings.Hosts = new List<ClientHostSettings.HostInfo>();

                ClientHostSettings.HostInfo current = settings.Hosts.Where(x => x.Id == client.ClientId).FirstOrDefault();

                if (current == null)
                {
                    current = new ClientHostSettings.HostInfo();
                    current.Id = client.ClientId;
                }

                current.Name = client.ClientName;
                current.Ip = client.ClientIp;
                current.LastUpdate = DateTime.Now.ToString();
                current.CPUUsagePercent = client.CPUUsagePercent;
                current.RAMUsedPercent = client.RAMUsedPercent;
                current.Disks = new List<ClientHostSettings.DiskInfo>();
                foreach (var d in client.Disks)
                {
                    current.Disks.Add(new ClientHostSettings.DiskInfo()
                    {
                        Name = d.Name,
                        TotalSize = d.TotalSize,
                        FreeTotalSpace = d.FreeTotalSpace,
                        UsedSpace = d.UsedSpace
                    });
                }
                current.WebService_CurrentConnections = client.WebService_CurrentConnections;

                if (!settings.Hosts.Any(x => x.Id == current.Id))
                {
                    settings.Hosts.Add(current);
                }

                LogHelper.Logger.Error(JsonConvert.SerializeObject(settings));
                try
                {
                    settingsManager.SaveSettings(settings);
                }
                catch (Exception ex)
                {
                    LogHelper.Logger.Error("出错了：" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 获取当前所有监控的主机（往监控台发数据)
        /// </summary>
        /// <returns></returns>
        public static List<ClientHostSettings.HostInfo> GetHosts()
        {
            return Settings?.Hosts ?? new List<ClientHostSettings.HostInfo>();
        }

        public override bool IsMember(string node)
        {
            return false;
        }

        #region ClientInfo json
        public class HostJsonInfo
        {
            public int ClientId { get; set; }
            public string ClientName { get; set; }
            public string ClientIp { get; set; }
            public float CPUUsagePercent { get; set; }
            public float RAMUsedPercent { get; set; }

            public List<DiskJsonInfo> Disks { get; set; }

            public float WebService_CurrentConnections { get; set; }
        }

        public class DiskJsonInfo
        {
            public string Name { get; set; }
            public long TotalSize { get; set; }
            public long FreeTotalSpace { get; set; }
            public long UsedSpace { get; set; }
        }
        #endregion
    }
}
