using System.Threading.Tasks;

namespace POC.RabbitMQ.Contracts
{
    public interface IMessageHandler<in TMessage>
    {
        Task HandleAsync(TMessage message);
    }
}
