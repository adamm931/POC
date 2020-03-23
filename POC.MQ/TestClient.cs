using RabbitMQ.Client;

namespace POC.MQ
{
    public class TestClinet
    {
        public TestClinet()
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost", //this will be container ip address
                Port = 123, // this will be container port
            };

            var connection = connectionFactory.CreateConnection();

            var channel = connection.CreateModel();

            var queue = channel.QueueDeclare(
                queue: "PocDefault",
                durable: true,
                exclusive: false,
                autoDelete: true);

        }
    }
}
