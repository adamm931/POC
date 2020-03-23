using FluentValidation;
using POC.Accounts.Contracts;
using POC.Accounts.Service.UseCases.Base;
using POC.Accounts.Service.UseCases.Model;
using POC.Accounts.Service.UseCases.Validation;
using POC.Common.Service;
using POC.Configuration.Mapping;
using System.Threading.Tasks;

namespace POC.Accounts.Service.UseCases.GetAccountByUsername
{
    public class GetAccountByUsernameServiceRequest : IServiceRequest<AccountServiceResponse>
    {
        public string Username { get; set; }

        public class Handler : AccountServiceHandler<GetAccountByUsernameServiceRequest, AccountServiceResponse>
        {
            public Handler(IAccountContext accountContext, IMapping mapper) : base(accountContext, mapper)
            {
            }

            public async override Task<AccountServiceResponse> Handle(GetAccountByUsernameServiceRequest request)
            {
                var account = await AccountContext.GetAccountByUsername(request.Username);

                return Mapper.Map<AccountServiceResponse>(account);
            }
        }

        public class Validator : AbstractValidator<GetAccountByUsernameServiceRequest>
        {
            public Validator(IAccountContext context)
            {
                RuleFor(model => model.Username).ExistingAccountByUsername(context);
            }
        }
    }
}