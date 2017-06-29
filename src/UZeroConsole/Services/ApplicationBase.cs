using U;
using U.Application.Services.Events;

namespace UZeroConsole.Services
{
    public abstract class ApplicationBase : U.Application.Services.ApplicationService
    {
        public IEventPublisher EventPublisher;
        public ApplicationBase() {
            EventPublisher = UPrimeEngine.Instance.Resolve<IEventPublisher>();
        }
    }
}
