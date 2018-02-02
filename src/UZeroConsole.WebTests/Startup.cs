using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(UZeroConsole.WebTests.Startup))]

namespace UZeroConsole.WebTests
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var a = 1;
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
