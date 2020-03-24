using POC.MQ.Contracts;
using RabbitMQ.Client;
using System.Threading.Tasks;

namespace POC.MQ.Internal
{
    public class BusConsumer : IBusConsumer
    {
        private readonly IModel _rabbitMQ;

        public BusConsumer(IModel rabbitMQ)
        {
            _rabbitMQ = rabbitMQ;
        }

        public async Task ConsumeAsync(string quename)
        {
            throw new System.NotImplementedException();
        }
    }
}
