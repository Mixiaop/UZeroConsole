using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using U;
using UZeroConsole.Logging;

namespace UZeroConsole.WebTests
{
    public partial class ExceptionTests : System.Web.UI.Page
    {
        ILoggingService _loggingService = UPrimeEngine.Instance.Resolve<ILoggingService>();
        protected void Page_Load(object sender, EventArgs e)
        {
            //throw new Exception("UZeroConsole.WebTests exception");
            var list = _loggingService.GetActionTopLogs("18c1af7d487f483fb118e9b3cd517a21", "1462", 10);
            Response.Write(JsonConvert.SerializeObject(list));
            var a = 1;
        }
    }
}