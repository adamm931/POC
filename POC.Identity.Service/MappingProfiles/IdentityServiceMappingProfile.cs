using AutoMapper;
using POC.Identity.Models;
using POC.Identity.Service.UseCases.CheckUsername;
using POC.Identity.Service.UseCases.Login;
using POC.Identity.Service.UseCases.Signup;
using POC.Identity.Service.UseCases.UpdateLogin;

namespace POC.Identity.Service.MappingProfiles
{
    public class IdentityServiceMappingProfile : Profile
    {
        public IdentityServiceMappingProfile()
        {
            CreateMap<CheckUsernameServiceRequest, CheckUsernameRequest>();
            CreateMap<CheckUsernameResponse, CheckUsernameServiceResponse>();
            CreateMap<UserLoginServiceRequest, UserLoginRequest>();
            CreateMap<UserLoginResponse, UserLoginServiceResponse>();
            CreateMap<SignupUserServiceRequest, SignupUserRequest>();
            CreateMap<UpdateUserLoginServiceRequest, UpdateUserLoginRequest>();
        }
    }
}