using FluentValidation;
using POC.Common.Service;
using POC.Configuration.Mapping;
using POC.Identity.Contracts;
using POC.Identity.Domain.Entities;
using POC.Identity.Service.Events;
using POC.Identity.Service.UseCases.Base;
using POC.Identity.Service.UseCases.Validation;
using POC.MQ.Contracts;
using System.Threading.Tasks;

namespace POC.Identity.Service.UseCases.Signup
{
    public class SignupUserServiceRequest : IServiceRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public class Handler : IdentityServiceHandler<SignupUserServiceRequest>
        {
            private readonly IBusPublisher _busPublisher;

            public Handler(
                IIdentityContext identityContext,
                IMapping mapper,
                IBusPublisher busPublisher) : base(identityContext, mapper)
            {
                _busPublisher = busPublisher;
            }

            public override async Task Handle(SignupUserServiceRequest request)
            {
                IdentityContext.Logins.Add(new UserLogin(request.Username, request.Password));

                await IdentityContext.Save();

                await _busPublisher.PublishAsync(new UserSignuped(request.Username));
            }
        }

        public class Validator : AbstractValidator<SignupUserServiceRequest>
        {
            public Validator(ICredentialRequirmentValidator validator, IIdentityContext context)
            {
                RuleFor(model => model.Username).UniqueUsername(validator, context);

                RuleFor(model => model.Password).Password(validator);
            }
        }

    }
}