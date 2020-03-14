using POC.Identity.Models;
using System.Threading.Tasks;

namespace POC.Identity.Contracts
{
    public interface IIdentityApi
    {
        Task<UserLoginResponse> LoginAsync(UserLoginRequest request);

        Task UpdateLoginAsync(UpdateUserLoginRequest request);

        Task SignupAsync(SignupUserRequest request);

        Task<CheckUsernameResponse> CheckUsernameAsync(CheckUsernameRequest request);
    }
}
