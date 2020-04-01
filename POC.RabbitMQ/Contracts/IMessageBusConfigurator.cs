namespace POC.RabbitMQ.Contracts
{
    public interface IMessageBusConfigurator
    {
        void Configure(IMessageBus messageBus);
    }
}
