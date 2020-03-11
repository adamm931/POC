using AutoMapper;
using POC.Accounts.Domain;
using POC.Accounts.Model;

namespace POC.Accounts.MappingProfiles
{
    public class AccountMappingProfile : Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<AccountLogin, AccountLoginResponse>()
                .ForMember(dst => dst.AccountId, opts => opts.MapFrom(src => src.Account.Id));

            CreateMap<Account, AccountResponse>()
                .ForMember(dst => dst.Username, opts => opts.MapFrom(src => src.Login.Username));

            CreateMap<AccountAddress, AccountAddressResponse>();

            CreateMap<AccountLogin, UpdateAccountLoginResponse>();
        }
    }
}
