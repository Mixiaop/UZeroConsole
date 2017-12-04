using U;
using U.Application.Services.Events;
using UZeroConsole.Configuration;

namespace UZeroConsole.Services
{
    public abstract class ApplicationServiceBase : U.Application.Services.ApplicationService
    {
        public IEventPublisher EventPublisher;
        public ConsoleSettings Settings;
        public ApplicationServiceBase() {
            EventPublisher = UPrimeEngine.Instance.Resolve<IEventPublisher>();
            Settings = UPrimeEngine.Instance.Resolve<ConsoleSettings>();
        }
    }
}
