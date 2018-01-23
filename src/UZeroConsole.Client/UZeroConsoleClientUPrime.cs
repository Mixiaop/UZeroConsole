using System.Reflection;
using U.UPrimes;

namespace UZeroConsole.Client
{
    public class UZeroConsoleClientUPrime : UPrime
    {
        public override void Initialize()
        {
            Engine.IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
