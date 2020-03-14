using AutoMapper;
using POC.Accounts.Service.Model;
using POC.Web.Models;

namespace POC.Web.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountServiceResponse, AccountViewModel>()
                .ForMember(dst => dst.Header, opt => opt.MapFrom(src => src))
                .ForMember(dst => dst.Address, opt => opt.MapFrom(src => src.Address));

            CreateMap<AccountHeaderViewModel, AccountHeaderServiceRequest>();
            CreateMap<AccountAddressViewModel, AccountAddressServiceRequest>();

            CreateMap<AccountServiceResponse, AccountHeaderViewModel>();
            CreateMap<AccountAddressServiceResponse, AccountAddressViewModel>();

        }
    }
}