using System.Reflection;
using U.UPrimes;

namespace UZeroConsole.EntityFramework
{
    public class UZeroConsoleEntityFrameworkUPrime : UPrime
    {
        public override void Initialize()
        {
            Engine.IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

    }
}
