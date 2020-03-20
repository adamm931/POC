using AutoMapper;
using POC.Accounts.Model;
using POC.Accounts.Service.Model;
using POC.Accounts.Service.UseCases.Model;

namespace POC.Accounts.Service.MappingProfiles
{
    public class AccountMappingProfile : Profile
    {
        public AccountMappingProfile()
        {
            // service -> api
            CreateMap<AddAccountLoginServiceRequest, AccountLoginRequest>();
            CreateMap<AccountHeaderServiceRequest, AccountHeaderRequest>();
            CreateMap<AccountAddressServiceRequest, AccountAddressRequest>();
            CreateMap<UpdateAccountLoginServiceRequest, UpdateAccountLoginRequest>();

            // api -> service
            CreateMap<AccountLoginResponse, AddAccountLoginServiceResponse>();
            CreateMap<AccountResponse, AccountServiceResponse>();
            CreateMap<AccountAddressResponse, AccountAddressServiceResponse>();
            CreateMap<UpdateAccountLoginResponse, UpdateAccountLoginServiceResponse>();
        }
    }
}
