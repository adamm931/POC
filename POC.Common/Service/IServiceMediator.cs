using System.Threading.Tasks;

namespace POC.Common.Service
{
    public interface IServiceMediator
    {
        Task<ServiceResponse<TResponse>> Handle<TRequest, TResponse>(TRequest request)
            where TRequest : IServiceRequest<TResponse>;

        Task<ServiceResponse> Handle<TRequest>(TRequest request)
            where TRequest : IServiceRequest;
    }
}
