using System.Reflection;
using U.UPrimes;

namespace UZeroConsole.EntityFramework
{
    public class UZeroConsoleEntityFrameworkUPrime : U.UPrimes.UPrime
    {
        public override void Initialize()
        {
            Engine.IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

    }
}
