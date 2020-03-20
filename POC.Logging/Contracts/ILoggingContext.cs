using MongoDB.Driver;
using POC.Logging.Domain;

namespace POC.Logging.Contracts
{
    public interface ILoggingContext
    {
        IMongoCollection<LogEntry> LogEntries { get; }

        IMongoCollection<AuditEntry> AuditEntries { get; }
    }
}
