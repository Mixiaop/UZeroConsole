using System.Reflection;
using U.UPrimes;

namespace UZeroConsole.Logging
{
    public class UZeroConsoleLoggingUPrime : UPrime
    {
        public override void Initialize()
        {
            Engine.IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
