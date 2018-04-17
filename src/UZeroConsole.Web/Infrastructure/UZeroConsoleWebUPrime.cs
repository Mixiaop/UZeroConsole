using System.Reflection;
using U.UPrimes;
using U.EntityFramework;
//using U.Hangfire;
using UZeroConsole.EntityFramework;
using UZeroConsole.Configuration;

namespace UZeroConsole.Web
{
    [DependsOn(
        typeof(UEntityFrameworkUPrime),
        typeof(UZeroConsoleUPrime),
        typeof(UZeroConsoleEntityFrameworkUPrime)
        //typeof(UHangfireUPrime)
        )]
    public class UZeroConsoleWebUPrime : UPrime
    {
        public override void PreInitialize()
        {
            //if (Engine.Resolve<ConsoleSettings>().UseJobs)
            //{
            //    Engine.Configuration.BackgroundJob.IsJobExecutionEnabled = true;
            //}
        }

        public override void Initialize()
        {
            Engine.IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            //if (Engine.Resolve<ConsoleSettings>().UseJobs)
            //{
            //    Engine.Configuration.BackgroundJob.UseHangfire();
            //}
        }
    }
}