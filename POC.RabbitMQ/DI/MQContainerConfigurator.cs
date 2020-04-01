using POC.Configuration.DI;

namespace POC.RabbitMQ.DI
{
    public class MQContainerConfigurator : IContainerConfigurator
    {
        public void Configure(IContainer container)
        {
            container.RegisterRabbitMQ();
        }
    }
}
