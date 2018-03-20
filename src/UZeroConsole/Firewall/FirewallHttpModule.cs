using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UZeroConsole.Firewall
{
    public class FirewallHttpModule : System.Web.IHttpModule
    {
        public void Init(HttpApplication context)
        {
            var a = 1;    
        }

        public void Dispose()
        {

        }
    }
}
