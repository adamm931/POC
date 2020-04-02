using Newtonsoft.Json;
using System;
using System.Text;

namespace POC.RabbitMQ.Models
{
    public class BusMessage
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public BusMessage()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }

        public byte[] GetBytes()
        {
            var content = JsonConvert.SerializeObject(this);
            var bytes = Encoding.UTF8.GetBytes(content);

            return bytes;
        }

    }
}
