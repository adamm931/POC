using FluentValidation;
using POC.Common.Service.Validation;
using POC.Configuration.DI;
using System;
using System.Threading.Tasks;

namespace POC.Common.Service
{
    internal class ServiceMediator : IServiceMediator
    {
        private readonly IContainer _container;
        private readonly IServiceRequestValidator _requestValidator;

        internal ServiceMediator(IContainer container)
        {
            _container = container;
            _requestValidator = new ServiceRequestValidator(container);
        }

        public async Task<ServiceResponse<TResponse>> Handle<TRequest, TResponse>(TRequest request)
            where TRequest : IServiceRequest<TResponse>
        {
            try
            {
                await _requestValidator.ValidateAsync(request);

                var handler = GetHandler<TRequest, TResponse>();

                var response = await handler.Handle(request);

                return ServiceResponse<TResponse>.Success(response);
            }

            catch (ValidationException exception)
            {
                return ServiceResponse<TResponse>.Fail(exception.Message);
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
                await _requestValidator.ValidateAsync(request);

                var handler = GetHandler<TRequest>();

                await handler.Handle(request);

                return ServiceResponse.Success();
            }

            catch (ValidationException exception)
            {
                return ServiceResponse.Fail(exception.Message);
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

            return _container.RegisterThanResolve(handlerType) as IServiceHandler<TRequest>;
        }

        private IServiceHandler<TRequest, TResponse> GetHandler<TRequest, TResponse>()
            where TRequest : IServiceRequest<TResponse>
        {
            var handlerType = typeof(TRequest).Assembly
                .GetTypeOf<IServiceHandler<TRequest, TResponse>>();

            return _container.RegisterThanResolve(handlerType) as IServiceHandler<TRequest, TResponse>;
        }
    }
}
