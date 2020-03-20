using POC.Common.Service;
using POC.Configuration.Mapping;
using POC.Todos.Contracts;
using System.Threading.Tasks;

namespace POC.Todos.Service.UseCases.Base
{
    public abstract class TodoServiceHandler<TRequest, TResponse> : IServiceHandler<TRequest, TResponse>
        where TRequest : IServiceRequest<TResponse>
    {
        protected TodoServiceHandler(ITodoContext context, IMapping mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        protected ITodoContext Context { get; }

        protected IMapping Mapper { get; }

        public abstract Task<TResponse> Handle(TRequest request);
    }

    public abstract class TodoServiceHandler<TRequest> : IServiceHandler<TRequest>
        where TRequest : IServiceRequest
    {
        protected TodoServiceHandler(ITodoContext context, IMapping mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        protected ITodoContext Context { get; }

        protected IMapping Mapper { get; }

        public abstract Task Handle(TRequest request);
    }
}