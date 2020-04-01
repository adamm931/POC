using POC.Configuration.DI;

namespace POC.Common.Service.Factory
{
    public class ServiceMediatorFactory
    {
        public static IServiceMediator CreateMediator()
        {
            return new ServiceMediator(ContainerProvider.Container);
        }
    }
}
