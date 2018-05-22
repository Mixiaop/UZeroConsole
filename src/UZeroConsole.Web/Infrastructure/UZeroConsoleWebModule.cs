using System.Reflection;
using UPrime;
using UPrime.Modules;

namespace UZeroConsole.Web.Infrastructure
{
    [DependsOn(typeof(UZeroConsoleModule))]
    public class UZeroConsoleWebModule : UPrimeModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssembly(Assembly.GetExecutingAssembly());
        }
    }
}