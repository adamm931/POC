using MongoDB.Driver;
using POC.Common.Connection;
using POC.Logging.Domain;

namespace POC.Logging.Data
{
    public class LoggingContext
    {
        public IMongoDatabase Database { get; }

        public IMongoCollection<LogEntry> LogEntries { get; set; }

        public IMongoCollection<AuditEntry> AuditEntries { get; set; }

        public LoggingContext()
        {
            var connectionString = ConnectionStringFactory.GetMongoConnnectionString("Logging");
            var client = new MongoClient(connectionString.Value);

            Database = client.GetDatabase("Logging");

            LogEntries = Database.GetCollection<LogEntry>(nameof(LogEntries));
            AuditEntries = Database.GetCollection<AuditEntry>(nameof(AuditEntries));
        }
    }
}
