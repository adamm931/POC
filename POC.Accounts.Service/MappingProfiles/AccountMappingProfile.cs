using AutoMapper;
using POC.Accounts.Domain;
using POC.Accounts.Service.Model;
using POC.Accounts.Service.UseCases.Model;

namespace POC.Accounts.Service.MappingProfiles
{
    public class AccountMappingProfile : Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<AccountLogin, AddAccountLoginServiceResponse>();

            CreateMap<Account, AccountServiceResponse>()
                .ForMember(dst => dst.Username, opt => opt.MapFrom(src => src.Login.Username));

            CreateMap<AccountAddress, AccountAddressServiceResponse>();

            CreateMap<AccountLogin, UpdateAccountLoginServiceResponse>();
        }
    }
}
