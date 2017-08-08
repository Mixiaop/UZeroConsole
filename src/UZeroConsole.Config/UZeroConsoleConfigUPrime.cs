using System.Reflection;
using U.UPrimes;

namespace UZeroConsole.Config
{
    public class UZeroConsoleConfigUPrime : UPrime
    {
        public override void Initialize()
        {
            Engine.IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
