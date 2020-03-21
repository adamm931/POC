using POC.Identity.Domain.Enums;
using POC.Identity.Domain.Models;
using System.Threading.Tasks;

namespace POC.Identity.Contracts
{
    public interface ICredentialRequirmentValidator
    {
        Task<CredentialRequirmentValidationResult> ValidateAsync(CredentialType credentialType, string value);
    }
}
