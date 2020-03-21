using FluentValidation;
using POC.Common.Service;
using POC.Configuration.Mapping;
using POC.Identity.Contracts;
using POC.Identity.Domain.Entities;
using POC.Identity.Service.UseCases.Base;
using POC.Identity.Service.UseCases.Validation;
using System.Threading.Tasks;

namespace POC.Identity.Service.UseCases.Signup
{
    public class SignupUserServiceRequest : IServiceRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public class Handler : IdentityServiceHandler<SignupUserServiceRequest>
        {
            public Handler(IIdentityContext identityContext, IMapping mapper) : base(identityContext, mapper)
            {
            }

            public override async Task Handle(SignupUserServiceRequest request)
            {
                IdentityContext.Logins.Add(new UserLogin(request.Username, request.Password));

                await IdentityContext.Save();
            }
        }

        public class Validator : AbstractValidator<SignupUserServiceRequest>
        {
            public Validator(ICredentialRequirmentValidator credentialRequirmentValidator, IIdentityContext identityContext)
            {
                RuleFor(model => model.Username)
                    .SetValidator(new UniqueUsernameValidator(credentialRequirmentValidator, identityContext));

                RuleFor(model => model.Password)
                    .SetValidator(new PasswordValidator(credentialRequirmentValidator));
            }
        }

    }
}