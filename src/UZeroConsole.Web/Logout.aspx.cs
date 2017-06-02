using System;
using U;
using UZeroConsole.Services;

namespace UZeroConsole.Web
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IAuthenticationService authService = UPrimeEngine.Instance.Resolve<IAuthenticationService>();
            authService.SignOut();
            Response.Redirect("/");
        }
    }
}