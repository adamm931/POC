using FluentValidation;
using FluentValidation.Results;
using POC.Configuration.DI;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Common.Service.Validation
{
    public class ServiceRequestValidator : IServiceRequestValidator
    {
        private readonly IContainer _container;

        public ServiceRequestValidator(IContainer container)
        {
            _container = container;
        }

        public async Task ValidateAsync<TRequest>(TRequest request)
        {
            var requestAssembly = request.GetType().Assembly;

            var requestValidators = requestAssembly
                .GetTypesOf<AbstractValidator<TRequest>>();

            var invalidResults = new List<ValidationResult>();

            foreach (var requestValidatorType in requestValidators)
            {
                if (!_container.IsRegistered(requestValidatorType))
                {
                    _container.Register(requestValidatorType);
                }

                var validator = _container.Resolve(requestValidatorType) as AbstractValidator<TRequest>;

                var result = await validator.ValidateAsync(request);

                if (!result.IsValid)
                {
                    invalidResults.Add(result);
                }
            }

            if (invalidResults.Any())
            {
                var errors = invalidResults.SelectMany(ret => ret.Errors);
                throw new ValidationException(errors);
            }
        }
    }
}
