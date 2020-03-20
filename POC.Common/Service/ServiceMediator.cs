using POC.Configuration.DI;
using System;
using System.Threading.Tasks;

namespace POC.Common.Service
{
    public class ServiceMediator : IServiceMediator
    {
        private readonly IContainer _container;

        public ServiceMediator(IContainer container)
        {
            _container = container;
        }

        public async Task<ServiceResponse<TResponse>> Handle<TRequest, TResponse>(TRequest request)
            where TRequest : IServiceRequest<TResponse>
        {
            try
            {
                var handler = GetHandler<TRequest, TResponse>();

                var response = await handler.Handle(request);

                return ServiceResponse<TResponse>.Success(response);
            }

            catch (Exception exception)
            {
                return ServiceResponse<TResponse>.Fail(exception);
            }
        }

        public async Task<ServiceResponse> Handle<TRequest>(TRequest request)
            where TRequest : IServiceRequest
        {
            try
            {
                var handler = GetHandler<TRequest>();

                await handler.Handle(request);

                return ServiceResponse.Success();
            }

            catch (Exception exception)
            {
                return ServiceResponse.Fail(exception);
            }
        }

        private IServiceHandler<TRequest> GetHandler<TRequest>()
            where TRequest : IServiceRequest
        {
            var handlerType = typeof(TRequest).Assembly
                .GetTypeOf<IServiceHandler<TRequest>>();

            if (!_container.IsRegistered(handlerType))
            {
                _container.Register(handlerType);
            }

            var handler = _container.Resolve(handlerType) as IServiceHandler<TRequest>;

            return handler;
        }

        private IServiceHandler<TRequest, TResponse> GetHandler<TRequest, TResponse>()
            where TRequest : IServiceRequest<TResponse>
        {
            var handlerType = typeof(TRequest).Assembly
                .GetTypeOf<IServiceHandler<TRequest, TResponse>>();

            if (!_container.IsRegistered(handlerType))
            {
                _container.Register(handlerType);
            }

            var handler = _container.Resolve(handlerType) as IServiceHandler<TRequest, TResponse>;

            return handler;
        }
    }
}
