using POC.Identity.Models;
using System.Threading.Tasks;

namespace POC.Identity.Contracts
{
    public interface IUserService
    {
        Task<UserLoginResponse> LoginAsync(UserLoginRequest request);

        Task SignupAsync(SignupUserRequest request);

        Task<CheckUsernameResponse> CheckUsernameAsync(CheckUsernameRequest request);
    }
}
