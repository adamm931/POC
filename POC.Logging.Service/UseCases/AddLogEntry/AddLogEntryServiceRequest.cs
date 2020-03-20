using POC.Common.Service;
using POC.Logging.Contracts;
using POC.Logging.Domain;
using System.Threading.Tasks;

namespace POC.Logging.Service.Models.Log
{
    public class AddLogEntryServiceRequest : IServiceRequest
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public string Level { get; set; }

        public class Handler : IServiceHandler<AddLogEntryServiceRequest>
        {
            private readonly ILoggingContext _loggingContext;

            public Handler(ILoggingContext context)
            {
                _loggingContext = context;
            }

            public async Task Handle(AddLogEntryServiceRequest request)
            {
                var entry = new LogEntry(request.Title, request.Text, request.Level);

                await _loggingContext.LogEntries.InsertOneAsync(entry);
            }
        }
    }
}