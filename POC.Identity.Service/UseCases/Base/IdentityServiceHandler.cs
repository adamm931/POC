using POC.Common.Service;
using POC.Configuration.Mapping;
using POC.Identity.Contracts;
using System.Threading.Tasks;

namespace POC.Identity.Service.UseCases.Base
{
    public abstract class IdentityServiceHandler<TRequest> : IServiceHandler<TRequest>
        where TRequest : IServiceRequest
    {
        protected readonly IIdentityApi IdentityApi;

        protected readonly IMapping Mapper;

        public IdentityServiceHandler(IIdentityApi identityApi, IMapping mapper)
        {
            IdentityApi = identityApi;
            Mapper = mapper;
        }


        public abstract Task Handle(TRequest request);
    }

    public abstract class IdentityServiceHandler<TRequest, TResponse> : IServiceHandler<TRequest, TResponse>
        where TRequest : IServiceRequest<TResponse>
    {
        protected readonly IIdentityApi IdentityApi;

        protected readonly IMapping Mapper;

        public IdentityServiceHandler(IIdentityApi identityApi, IMapping mapper)
        {
            IdentityApi = identityApi;
            Mapper = mapper;
        }


        public abstract Task<TResponse> Handle(TRequest request);
    }
}