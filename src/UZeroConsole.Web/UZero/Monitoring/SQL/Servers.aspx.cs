using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UZeroConsole.Monitoring.SQL;
using UZeroConsole.Web.Models.Monitoring.SQL;

namespace UZeroConsole.Web.UZero.Monitoring.SQL
{
    public partial class Servers : MonitoringPageBase
    {
        protected ServersModel Model = new ServersModel()
        {
            StandaloneInstances = SQLModule.StandaloneInstances,
            Refresh = 5
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}