using POC.Configuration.DI;

namespace POC.Common.Service.Factory
{
    public class ServiceMediatorFactory
    {
        public static IServiceMediator CreateMediator<TService>()
        {
            var container = Container<TService>.Instance;

            return new ServiceMediator(container);
        }
    }
}
