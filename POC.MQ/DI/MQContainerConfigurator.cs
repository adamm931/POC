using POC.Configuration.DI;

namespace POC.MQ.DI
{
    public class MQContainerConfigurator : IContainerConfigurator
    {
        public void Configure(IContainer container)
        {
            container.RegisterPocMQ();
        }
    }
}
