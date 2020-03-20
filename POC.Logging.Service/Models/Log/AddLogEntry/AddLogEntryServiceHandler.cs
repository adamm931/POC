using POC.Common.Service;
using POC.Logging.Contracts;
using POC.Logging.Domain;
using System.Threading.Tasks;

namespace POC.Logging.Service.Models.Log.AddLogEntry
{
    public class AddLogEntryServiceHandler : IServiceHandler<AddLogEntryServiceRequest>
    {
        public AddLogEntryServiceHandler(ILoggingContext context)
        {
            Context = context;
        }

        public ILoggingContext Context { get; }

        public async Task Handle(AddLogEntryServiceRequest request)
        {
            var entry = new LogEntry(request.Title, request.Text, request.Level);

            await Context.LogEntries.InsertOneAsync(entry);
        }
    }
}