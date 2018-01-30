using System.Reflection;
using U.UPrimes;
using U.Dapper;

namespace UZeroConsole.Dapper
{
    [DependsOn(
        typeof(UDapperUPrime)
        )]
    public class UZeroConsoleDapperUPrime : UPrime
    {
        public override void PreInitialize()
        {
            Engine.IocManager.Register<UZeroConsoleDapperContextProvider, UZeroConsoleDapperContextProvider>();
            Engine.IocManager.Register<UZeroConsoleDapperConfiguration, UZeroConsoleDapperConfiguration>();
        }

        public override void Initialize()
        {
            Engine.IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
