using FluentValidation;
using POC.Accounts.Contracts;
using POC.Accounts.Service.UseCases.Base;
using POC.Accounts.Service.UseCases.Model;
using POC.Accounts.Service.UseCases.Validation;
using POC.Common.Service;
using POC.Configuration.Mapping;
using System;
using System.Threading.Tasks;

namespace POC.Accounts.Service.UseCases.GetAccountById
{
    public class GetAccountByIdServiceRequest : IServiceRequest<AccountServiceResponse>
    {
        public Guid Id { get; set; }

        public class Handler : AccountServiceHandler<GetAccountByIdServiceRequest, AccountServiceResponse>
        {
            public Handler(IAccountContext accountConext, IMapping mapper) : base(accountConext, mapper)
            {
            }

            public override async Task<AccountServiceResponse> Handle(GetAccountByIdServiceRequest request)
            {
                var account = await AccountContext.GetAccountById(request.Id);

                return Mapper.Map<AccountServiceResponse>(account);
            }
        }

        public class Validator : AbstractValidator<GetAccountByIdServiceRequest>
        {
            public Validator(IAccountContext context)
            {
                RuleFor(model => model.Id).ExistingAccountById(context);
            }
        }
    }
}