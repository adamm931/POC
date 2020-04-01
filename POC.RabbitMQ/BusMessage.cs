using Newtonsoft.Json;
using POC.RabbitMQ.Contracts;
using System;
using System.Text;

namespace POC.RabbitMQ
{
    public class BusMessage<TPayload> where TPayload : IMessagePayload
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public TPayload Payload { get; set; }

        public BusMessage(TPayload payload)
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;

            Payload = payload;
        }

        public byte[] GetBytes()
        {
            var content = JsonConvert.SerializeObject(this);
            var bytes = Encoding.UTF8.GetBytes(content);

            return bytes;
        }

        public static BusMessage<TPayload> FromBytes(byte[] payload)
        {
            var content = Encoding.UTF8.GetString(payload);

            return JsonConvert.DeserializeObject<BusMessage<TPayload>>(content);
        }

    }
}
