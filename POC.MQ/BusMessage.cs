using Newtonsoft.Json;
using System;
using System.Text;

namespace POC.MQ
{
    public class BusMessage
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string RouteKey { get; set; }

        public string Exchange { get; set; }

        protected BusMessage(string routeKey, string exchange)
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;

            RouteKey = routeKey;
            Exchange = exchange;
        }

        //[JsonConstructor]
        //public BusMessage(Guid id, DateTime createdAt, string name, string route)
        //{
        //    Id = id;
        //    Body = body;
        //    CreatedAt = createdAt;
        //    Name = name;
        //}

        public byte[] GetBytes()
        {
            var content = JsonConvert.SerializeObject(this);
            var bytes = Encoding.UTF8.GetBytes(content);

            return bytes;
        }
    }
}
