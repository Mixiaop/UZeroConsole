using System.Reflection;
using U;
using U.UPrimes;
using U.AutoMapper;
using UZeroConsole.Services.Mappers;

namespace UZeroConsole
{
     [DependsOn(
        typeof(ULeadershipUPrime),
        typeof(UAutoMapperUPrime)
        )]
    public class UZeroConsoleUPrime : UPrime
    {
         public override void Initialize()
         {
             Engine.IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
             CustomDtoMapper.CreateMappings();
         }
    }
}
