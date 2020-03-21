using System.Threading.Tasks;

namespace POC.Identity.Contracts
{
    public interface IValidatableCredential
    {
        Task ValidateOrThrow();
    }
}
