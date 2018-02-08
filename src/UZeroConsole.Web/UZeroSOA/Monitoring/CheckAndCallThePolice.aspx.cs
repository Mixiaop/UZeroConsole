using System;
using U;
using UZeroConsole.Services.Monitoring;

namespace UZeroConsole.Web.UZeroSOA.Monitoring
{
    public partial class CheckAndCallThePolice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UPrimeEngine.Instance.Resolve<ICallThePoliceService>().CheckOrCall();
        }
    }
}