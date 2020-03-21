using POC.Accounts.Contracts;
using POC.Common.Service;
using POC.Configuration.Mapping;
using System.Threading.Tasks;

namespace POC.Accounts.Service.UseCases.Base
{
    public abstract class AccountServiceHandler<TRequest, TResponse> : IServiceHandler<TRequest, TResponse>
        where TRequest : IServiceRequest<TResponse>
    {
        protected readonly IAccountContext AccountContext;
        protected readonly IMapping Mapper;

        public AccountServiceHandler(IAccountContext accountContext, IMapping mapper)
        {
            AccountContext = accountContext;
            Mapper = mapper;
        }

        public abstract Task<TResponse> Handle(TRequest request);
    }

    public abstract class AccountServiceHandler<TRequest> : IServiceHandler<TRequest>
        where TRequest : IServiceRequest
    {
        protected readonly IAccountContext AccountConext;
        protected readonly IMapping Mapper;

        public AccountServiceHandler(IAccountContext accountContext, IMapping mapper)
        {
            AccountConext = accountContext;
            Mapper = mapper;
        }

        public abstract Task Handle(TRequest request);
    }
}