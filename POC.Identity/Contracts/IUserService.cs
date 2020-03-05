using POC.Identity.Models;
using System.Threading.Tasks;

namespace POC.Identity.Contracts
{
    public interface IUserService
    {
        Task<UserLoginResponse> LoginAsync(UserLoginRequest request);
    }
}
