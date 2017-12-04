using System;
using U;
using U.Utilities.Web;
using UZeroConsole.Services.Sso;

namespace UZeroConsole.Web.UZeroSOA.Sso
{
    /// <summary>
    /// Sso授权页，会授权session下所有的应用，并跳转到首个应用
    /// </summary>
    public partial class SignIn : System.Web.UI.Page
    {
        ISsoAuthenticationService _authenticationService = UPrimeEngine.Instance.Resolve<ISsoAuthenticationService>();
        ISsoWebService _webService = UPrimeEngine.Instance.Resolve<ISsoWebService>();
        protected void Page_Load(object sender, EventArgs e)
        {
            var getSession = WebHelper.GetString("session");
            if (getSession.IsNullOrEmpty())
            {
                Response.Write("session is null");
                Response.End();
            }

            var session = _authenticationService.GetSession(getSession);
            if (session != null)
            {
                //授权当前应用
                _webService.SignInAndContinue(session);
            }
            else
            {
                Response.Write("session not found");
                Response.End();
            }
        }
    }
}