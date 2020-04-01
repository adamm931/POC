using FluentValidation;
using POC.Common.Service;
using POC.Configuration.Mapping;
using POC.Identity.Contracts;
using POC.Identity.Domain.Entities;
using POC.Identity.Service.UseCases.Base;
using POC.Identity.Service.UseCases.Validation;
using POC.RabbitMQ.Contracts;
using POC.RabbitMQ.Events;
using System.Threading.Tasks;

namespace POC.Identity.Service.UseCases.Signup
{
    public class SignupUserServiceRequest : IServiceRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public class Handler : IdentityServiceHandler<SignupUserServiceRequest>
        {
            private readonly IMessageBus _messageBus;

            public Handler(
                IIdentityContext identityContext,
                IMapping mapper,
                IMessageBus messageBus) : base(identityContext, mapper)
            {
                _messageBus = messageBus;
            }

            public override async Task Handle(SignupUserServiceRequest request)
            {
                IdentityContext.Logins.Add(new UserLogin(request.Username, request.Password));

                await IdentityContext.Save();

                _messageBus.Publish(new UserSignuped(request.Username));
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