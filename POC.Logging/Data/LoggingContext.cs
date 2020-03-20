using MongoDB.Driver;
using POC.Common.Connection;
using POC.Logging.Contracts;
using POC.Logging.Domain;

namespace POC.Logging.Data
{
    public class LoggingContext : ILoggingContext
    {
        public IMongoCollection<LogEntry> LogEntries { get; set; }

        public IMongoCollection<AuditEntry> AuditEntries { get; set; }

        public LoggingContext()
        {
            var connectionString = ConnectionStringFactory.GetMongoConnnectionString("Logging");
            var client = new MongoClient(connectionString.Value);

            var databse = client.GetDatabase("Logging");

            LogEntries = databse.GetCollection<LogEntry>(nameof(LogEntries));
            AuditEntries = databse.GetCollection<AuditEntry>(nameof(AuditEntries));
        }
    }
}
