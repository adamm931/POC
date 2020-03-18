﻿using AutoMapper;
using POC.Accounts.Service.Model;
using POC.Identity.Service.Models;
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

            CreateMap<UpdateLoginViewModel, UpdateAccountLoginServiceRequest>()
                .ForMember(dst => dst.AccountUsername, opt => opt.Ignore())
                .ForMember(dst => dst.AccountNewUsername, opt => opt.MapFrom(src => src.Username));

            CreateMap<UpdateLoginViewModel, UpdateUserLoginServiceRequest>()
                .ForMember(dst => dst.Username, opt => opt.Ignore())
                .ForMember(dst => dst.NewUsername, opt => opt.MapFrom(src => src.Username))
                .ForMember(dst => dst.NewPassword, opt => opt.MapFrom(src => src.Password));
        }
    }
}