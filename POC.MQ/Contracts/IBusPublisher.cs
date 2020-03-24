using System.Threading.Tasks;

namespace POC.MQ.Contracts
{
    public interface IBusPublisher
    {
        Task PublishAsync<TMessage>(TMessage message) where TMessage : BusMessage;
    }
}
