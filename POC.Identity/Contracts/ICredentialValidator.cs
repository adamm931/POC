using POC.Identity.Domain.Enums;
using POC.Identity.Domain.Models;
using System.Threading.Tasks;

namespace POC.Identity.Contracts
{
    public interface ICredentialValidator
    {
        Task<CredentialValidationResult> Validate(CredentialType credentialType, string value);
    }
}
