using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using U;
using U.Logging;
using U.Settings;
using UZeroConsole.Configuration.Monitoring;

namespace UZeroConsole.Web.UZeroSOA.Monitoring
{
    /// <summary>
    /// 接收客户端主机POST过来的性能信息
    /// </summary>
    public partial class Server : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var settings2 = UPrimeEngine.Instance.Resolve<ClientHostSettings>();
            //Response.Write("Settings:" + (settings2 == null).ToString());

            //LogHelper.Logger.Error();
            //LogHelper.Logger.Error("SettingsHosts:" + (settings2.Hosts == null).ToString());
            //Response.End();

            var reqData = "";
            using (StreamReader sr = new StreamReader(Request.InputStream))
            {
                reqData = sr.ReadLine();
            }

            if (reqData.IsNotNullOrEmpty())
            {

                var settings = UPrimeEngine.Instance.Resolve<ClientHostSettings>();
                var settingsManager = UPrimeEngine.Instance.Resolve<ISettingsManager>();

                var jsonObj = JsonConvert.DeserializeObject(reqData);
                var client = JsonConvert.DeserializeObject<HostInfo>(jsonObj.ToString());

               

                if (settings.Hosts == null)
                    settings.Hosts = new List<ClientHostSettings.HostInfo>();

                ClientHostSettings.HostInfo current = settings.Hosts.Where(x => x.Id == client.ClientId).FirstOrDefault();
                
                if (current == null)
                {
                    current = new ClientHostSettings.HostInfo();
                    current.Id = client.ClientId;
                    current.Name = client.ClientName;
                }

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
                    Response.Write("SUS");
                    Response.End();
                }
                catch (Exception ex) {
                    LogHelper.Logger.Error("出错了：" + ex.Message);
                }
            }
        }

        public class HostInfo
        {
            public int ClientId { get; set; }
            public string ClientName { get; set; }
            public float CPUUsagePercent { get; set; }
            public float RAMUsedPercent { get; set; }

            public List<DiskInfo> Disks { get; set; }

            public float WebService_CurrentConnections { get; set; }
        }

        public class DiskInfo
        {
            public string Name { get; set; }
            public long TotalSize { get; set; }
            public long FreeTotalSpace { get; set; }
            public long UsedSpace { get; set; }
        }
    }
}