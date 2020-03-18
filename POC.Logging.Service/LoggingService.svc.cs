using POC.Logging.Data;
using POC.Logging.Domain;
using POC.Logging.Service.Contracts;
using POC.Logging.Service.Models;
using System;
using System.Threading.Tasks;

namespace POC.Logging.Service
{
    public class LoggingService : ILoggingService
    {
        public LoggingService()
        {

        }

        public async Task AddLogEntryAsync(AddLogEntryServiceRequest request)
        {
            var loggingContext = new LoggingContext();

            var logEntry = new LogEntry(request.Title, request.Text, request.Level);

            try
            {
                await loggingContext.LogEntries.InsertOneAsync(logEntry);
            }

            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
