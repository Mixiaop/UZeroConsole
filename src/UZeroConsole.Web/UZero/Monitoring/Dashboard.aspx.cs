using System;
using UZeroConsole.Monitoring.Hosts;
using UZeroConsole.Monitoring.Redis;
using UZeroConsole.Monitoring.SQL;
using UZeroConsole.Web.Models.Monitoring;

namespace UZeroConsole.Web.UZero.Monitoring
{
    public partial class Dashboard : MonitoringPageBase
    {
        //protected DashboardModel Model = new DashboardModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Model.Hosts = HostModule.GetHosts();
            //Model.StandaloneInstances = SQLModule.StandaloneInstances;
            //Model.RedisInstances = RedisInstance.GetAll("");
        }
    }
}