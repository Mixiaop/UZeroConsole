using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
//using Hangfire;
//using Hangfire.Dashboard;
using U;
using U.Reflection;
using UZeroConsole.Configuration;
using UZeroConsole.Web.Infrastructure;

[assembly: OwinStartup(typeof(UZeroConsole.Web.Startup))]

namespace UZeroConsole.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //if (UPrimeEngine.Instance.Resolve<ConsoleSettings>().UseJobs)
            //{
            //    // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888

            //    var authList = new List<IAuthorizationFilter>();
            //    authList.Add(new HangfireAuthorizationFilter());
            //    var option = new DashboardOptions();
            //    option.AuthorizationFilters = authList;
            //    app.UseHangfireDashboard("/jobs", option);
            //}

            //路由配置
            ITypeFinder typeFinder = UPrimeEngine.Instance.Resolve<ITypeFinder>();
            var providerTypes = typeFinder.FindClassesOfType<IOwinStartupRegistrar>();
            var providers = new List<IOwinStartupRegistrar>();
            foreach (var providerType in providerTypes)
            {
                var provider = Activator.CreateInstance(providerType) as IOwinStartupRegistrar;

                providers.Add(provider);
            }
            providers = providers.ToList();
            if (providers.Count > 0)
                providers.ForEach(x => x.Register(app));
        }
    }
}