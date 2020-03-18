using POC.Logging.Service.Models;
using System.ServiceModel;
using System.Threading.Tasks;

namespace POC.Logging.Service.Contracts
{
    [ServiceContract]
    public interface ILoggingService
    {
        [OperationContract]
        Task AddLogEntryAsync(AddLogEntryServiceRequest request);
    }
}
