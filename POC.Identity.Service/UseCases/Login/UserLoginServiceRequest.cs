using FluentValidation;
using POC.Common.Service;
using POC.Configuration.Mapping;
using POC.Identity.Contracts;
using POC.Identity.Service.UseCases.Base;
using POC.Identity.Service.UseCases.Validation;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Identity.Service.UseCases.Login
{
    public class UserLoginServiceRequest : IServiceRequest<UserLoginServiceResponse>
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public class Handler : IdentityServiceHandler<UserLoginServiceRequest, UserLoginServiceResponse>
        {
            public Handler(IIdentityContext identityContext, IMapping mapper) : base(identityContext, mapper)
            {
            }

            public override async Task<UserLoginServiceResponse> Handle(UserLoginServiceRequest request)
            {
                var logins = await IdentityContext.Logins.ToListAsync();

                return new UserLoginServiceResponse
                {
                    IsAuthenticated = logins.Any(login => login.Challenge(request.Username, request.Password))
                };
            }
        }

        public class Validator : AbstractValidator<UserLoginServiceRequest>
        {
            public Validator(ICredentialRequirmentValidator credentialRequirmentValidator)
            {
                RuleFor(model => model.Password)
                    .SetValidator(new PasswordValidator(credentialRequirmentValidator));

                RuleFor(model => model.Username)
                    .SetValidator(new UsernameValidator(credentialRequirmentValidator));
            }
        }

    }
}