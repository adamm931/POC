using POC.Common.Service;
using POC.Logging.Service.Models.Log;
using System.ServiceModel;
using System.Threading.Tasks;

namespace POC.Logging.Service.Contracts
{
    [ServiceContract]
    public interface ILoggingService
    {
        [OperationContract]
        Task<ServiceResponse> AddLogEntryAsync(AddLogEntryServiceRequest request);

        [OperationContract]
        Task<ServiceResponse<ListLogEntriesServiceResponse>> QueryLogEntriesAsync(ListLogEntriesServiceRequest request);
    }
}
