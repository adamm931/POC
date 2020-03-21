using AutoMapper;
using POC.Accounts.Service.Model;
using POC.Accounts.Service.UseCases.Model;
using POC.Accounts.Service.UseCases.UpdateAccountAddress;
using POC.Accounts.Service.UseCases.UpdateAccountHeader;
using POC.Identity.Service.UseCases.UpdateLogin;
using POC.Todos.Service.UseCases.ListTodos;
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

            CreateMap<AccountHeaderViewModel, UpdateAccountHeaderServiceRequest>();
            CreateMap<AccountAddressViewModel, UpdateAccountAddressServiceRequest>();

            CreateMap<AccountServiceResponse, AccountHeaderViewModel>();
            CreateMap<AccountAddressServiceResponse, AccountAddressViewModel>();

            CreateMap<UpdateLoginViewModel, UpdateAccountLoginServiceRequest>()
                .ForMember(dst => dst.AccountUsername, opt => opt.Ignore())
                .ForMember(dst => dst.AccountNewUsername, opt => opt.MapFrom(src => src.Username));

            CreateMap<UpdateLoginViewModel, UpdateUserLoginServiceRequest>()
                .ForMember(dst => dst.Username, opt => opt.Ignore())
                .ForMember(dst => dst.NewUsername, opt => opt.MapFrom(src => src.Username))
                .ForMember(dst => dst.NewPassword, opt => opt.MapFrom(src => src.Password));

            CreateMap<ListTodosItemServiceResponse, TodoListItemViewModel>();
        }
    }
}