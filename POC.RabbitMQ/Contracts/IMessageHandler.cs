using POC.RabbitMQ.Models;
using System.Threading.Tasks;

namespace POC.RabbitMQ.Contracts
{
    public interface IMessageHandler<in TMessage> where TMessage : BusMessage
    {
        Task HandleAsync(TMessage message);
    }
}
