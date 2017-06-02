using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using U.FakeMvc.Routes;

namespace UZeroConsole.Web.Infrastructure
{
    public class UZeroConsoleWebRouteProvider : IRouteProvider
    {
        public void RegisterRewriterRole(RouteContext context)
        { 
        
        }

        public void RegisterRoutes(RouteContext context)
        {
        }

        private string Format(string url) {
            return string.Format("{0}{1}", "/", url.TrimStart('/'));
        }
    }
}