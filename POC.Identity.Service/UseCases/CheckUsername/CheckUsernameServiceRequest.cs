using FluentValidation;
using POC.Common.Service;
using POC.Configuration.Mapping;
using POC.Identity.Contracts;
using POC.Identity.Service.UseCases.Base;
using POC.Identity.Service.UseCases.Validation;
using System.Threading.Tasks;

namespace POC.Identity.Service.UseCases.CheckUsername
{
    public class CheckUsernameServiceRequest : IServiceRequest<CheckUsernameServiceResponse>
    {
        public string Username { get; set; }

        public class Handler : IdentityServiceHandler<CheckUsernameServiceRequest, CheckUsernameServiceResponse>
        {
            public Handler(IIdentityContext identityContext, IMapping mapper) : base(identityContext, mapper)
            {
            }

            public override async Task<CheckUsernameServiceResponse> Handle(CheckUsernameServiceRequest request)
            {
                var exists = await IdentityContext.UsernameExists(request.Username);

                return new CheckUsernameServiceResponse
                {
                    IsAvailable = !exists
                };
            }
        }

        public class Validator : AbstractValidator<CheckUsernameServiceRequest>
        {
            public Validator(ICredentialRequirmentValidator credentialRequirmentValidator)
            {
                RuleFor(model => model.Username).SetValidator(new UsernameValidator(credentialRequirmentValidator));
            }
        }
    }
}