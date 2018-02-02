using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using U;
using UZeroConsole.Configuration.Monitoring;

namespace UZeroConsole.Web.UZero.Monitoring.Hosts
{
    public partial class ClientHosts : MonitoringPageBase
    {
        protected ClientHostSettings Settings = UPrimeEngine.Instance.Resolve<ClientHostSettings>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}