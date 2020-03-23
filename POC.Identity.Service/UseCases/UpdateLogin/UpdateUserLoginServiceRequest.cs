using FluentValidation;
using POC.Common.Service;
using POC.Configuration.Mapping;
using POC.Identity.Contracts;
using POC.Identity.Service.UseCases.Base;
using POC.Identity.Service.UseCases.Validation;
using System.Data.Entity;
using System.Threading.Tasks;

namespace POC.Identity.Service.UseCases.UpdateLogin
{
    public class UpdateUserLoginServiceRequest : IServiceRequest
    {
        public string Username { get; set; }

        public string NewUsername { get; set; }

        public string NewPassword { get; set; }

        public class Handler : IdentityServiceHandler<UpdateUserLoginServiceRequest>
        {
            public Handler(IIdentityContext identityContext, IMapping mapper) : base(identityContext, mapper)
            {
            }

            public override async Task Handle(UpdateUserLoginServiceRequest request)
            {
                var login = await IdentityContext
                    .Logins
                    .SingleAsync(item => item.Username.Value == request.Username);

                login.Update(request.NewUsername, request.NewPassword);

                await IdentityContext.Save();
            }
        }

        public class Validator : AbstractValidator<UpdateUserLoginServiceRequest>
        {
            public Validator(ICredentialRequirmentValidator validator, IIdentityContext context)
            {
                RuleFor(model => model.NewPassword).Password(validator);

                RuleFor(model => model.Username).ExistingUsername(validator, context);

                RuleFor(model => model.NewUsername).UniqueUsername(validator, context);
            }
        }
    }
}