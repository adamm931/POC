using FluentValidation;
using POC.Accounts.Contracts;
using POC.Accounts.Service.UseCases.Base;
using POC.Accounts.Service.UseCases.Validation;
using POC.Common.Service;
using POC.Configuration.Mapping;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace POC.Accounts.Service.UseCases.UpdateAccountHeader
{
    public class UpdateAccountHeaderServiceRequest : IServiceRequest
    {
        public string AccountUsername { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Gender { get; set; }

        public DateTime BirthDay { get; set; }

        public class Handler : AccountServiceHandler<UpdateAccountHeaderServiceRequest>
        {
            public Handler(IAccountContext accountContext, IMapping mapper) : base(accountContext, mapper)
            {
            }

            public async override Task Handle(UpdateAccountHeaderServiceRequest request)
            {
                var account = await AccountConext.Accounts
                    .Include(model => model.Address)
                    .Include(model => model.Login)
                    .SingleAsync(model => model.Login.Username == request.AccountUsername);

                account.UpdateHeader(
                    request.FirstName,
                    request.MiddleName,
                    request.LastName,
                    request.BirthDay,
                    request.Gender);

                await AccountConext.Save();
            }
        }

        public class Validator : AbstractValidator<UpdateAccountHeaderServiceRequest>
        {
            public Validator(IAccountContext context)
            {
                RuleFor(model => model.AccountUsername).ExistingAccountByUsername(context);
                RuleFor(model => model.FirstName).NotEmpty();
                RuleFor(model => model.LastName).NotEmpty();
                RuleFor(model => model.MiddleName).NotEmpty();
                RuleFor(model => model.BirthDay).NotEmpty().LessThan(model => DateTime.UtcNow);

                RuleFor(model => model.Gender)
                    .NotEmpty()
                    .Must(model => Domain.Gender.IsValidGender(model))
                    .WithMessage(model => $"Invalid value: {model.Gender} for gender. The value can be: {string.Join(", ", Domain.Gender.AllNames)}");
            }
        }
    }
}