using System;
using System.Collections.Generic;
using UZeroConsole.Configuration.Monitoring;
using UZeroConsole.Monitoring.Hosts;

namespace UZeroConsole.Web.UZero.Monitoring.Hosts
{
    public partial class ClientHosts : MonitoringPageBase
    {
        protected List<ClientHostSettings.HostInfo> Hosts = HostModule.GetHosts();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}