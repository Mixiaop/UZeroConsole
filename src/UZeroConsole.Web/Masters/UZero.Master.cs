using System;
using U;
using UZeroConsole.Configuration;

namespace UZeroConsole.Web.Masters
{
    public partial class UZero : System.Web.UI.MasterPage
    {
        protected ConsoleSettings ConsoleSettings = UPrimeEngine.Instance.Resolve<ConsoleSettings>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}