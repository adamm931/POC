using POC.Common.Service;
using POC.Configuration.DI;
using POC.Logging.Domain;
using POC.Logging.Service.Contracts;
using POC.Logging.Service.Models.Log;
using System.Threading.Tasks;

namespace POC.Logging.Service
{
    public class LoggingService : ILoggingService
    {
        public LoggingService(IServiceMediator mediator)
        {
            ServiceMediator = mediator;
        }

        public LoggingService() : this(new ServiceMediator(ContainerHolder<LoggingService>.Container))
        {
            var blackhole = ContainerHolder<LogEntry>.Container;
        }

        public IServiceMediator ServiceMediator { get; }

        public async Task<ServiceResponse> AddLogEntryAsync(AddLogEntryServiceRequest request)
        {
            return await ServiceMediator.Handle(request);
        }

        public async Task<ServiceResponse<ListLogEntriesServiceResponse>> QueryLogEntriesAsync(ListLogEntriesServiceRequest request)
        {
            return await ServiceMediator.Handle<ListLogEntriesServiceRequest, ListLogEntriesServiceResponse>(request);
        }
    }
}
