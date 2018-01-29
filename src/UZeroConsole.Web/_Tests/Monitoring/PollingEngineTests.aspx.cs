using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UZeroConsole.Monitoring;

namespace UZeroConsole.Web._Tests.Monitoring
{
    public partial class PollingEngineTests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PollingEngine.StartPolling();
        }
    }
}