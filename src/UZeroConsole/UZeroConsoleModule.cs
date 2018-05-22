using System.Reflection;
using UPrime;
using UPrime.Modules;

namespace UZeroConsole
{
    [DependsOn(
        typeof(UPrimeLeadershipModule),
        typeof(UPrimeAutoMapperModule)
        )]
    public class UZeroConsoleModule : UPrimeModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
