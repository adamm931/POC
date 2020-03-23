using System.Threading.Tasks;

namespace POC.Common.Service
{
    public interface IServiceHandler<TRequest>
        where TRequest : IServiceRequest
    {
        Task Handle(TRequest request);
    }

    public interface IServiceHandler<TRequest, TResponse>
        where TRequest : IServiceRequest<TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
}
