using System.Collections.Generic;
using UZeroConsole.Monitoring.SQL;

namespace UZeroConsole.Web.Models.Monitoring.SQL
{
    public class ServersModel: DashboardModel
    {
        public List<SQLInstance> StandaloneInstances { get; set; }
    }
}