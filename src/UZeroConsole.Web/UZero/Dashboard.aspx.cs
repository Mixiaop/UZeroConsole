using System;
using U;
using UZeroConsole.Configuration;

namespace UZeroConsole.Web.UZero
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected ConsoleSettings ConsoleSettings = UPrimeEngine.Instance.Resolve<ConsoleSettings>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}