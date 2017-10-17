using U;
using U.Application.Services.Events;

namespace UZeroConsole.Services
{
    public abstract class ApplicationServiceBase : U.Application.Services.ApplicationService
    {
        public IEventPublisher EventPublisher;
        public ApplicationServiceBase() {
            EventPublisher = UPrimeEngine.Instance.Resolve<IEventPublisher>();
        }
    }
}
