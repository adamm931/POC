namespace POC.RabbitMQ.Common
{
    public class Queues
    {
        public const string Default = "poc-queue";
    }

    public class Exchanges
    {
        public const string Default = "poc-exchange";
    }

    public class DeliveryMode
    {
        public const int Persistant = 2;
    }

    public class RoutesKeys
    {
        public const string UserUpdated = "user-login-updated";

        public const string UserSignuped = "user-signuped";
    }
}
