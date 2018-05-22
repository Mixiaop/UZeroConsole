using System.Reflection;
using U;
using U.UPrimes;

namespace UZeroConsole
{
    [DependsOn(
        typeof(ULeadershipUPrime)
        )]
    public class UZeroConsoleUPrime : U.UPrimes.UPrime
    {
         public override void Initialize()
         {
             Engine.IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
