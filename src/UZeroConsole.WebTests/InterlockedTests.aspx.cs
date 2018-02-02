using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
namespace UZeroConsole.WebTests
{
    public partial class InterlockedTests : System.Web.UI.Page
    {
        int _totalSuccess = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Interlocked.Increment(ref _totalSuccess);
            Response.Write(_totalSuccess);
        }
    }
}