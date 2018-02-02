using System;
using U.Utilities.Web;
using UZeroConsole.Monitoring.SQL;
using UZeroConsole.Web.Models.Monitoring.SQL;

namespace UZeroConsole.Web.UZero.Monitoring.SQL
{
    public partial class Databases : MonitoringPageBase
    {
        protected DashboardModel Model = new DashboardModel()
        {
            CurrentInstance = SQLModule.Get(WebHelper.GetString("node")),
            Refresh = 2 * 60
        };
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}