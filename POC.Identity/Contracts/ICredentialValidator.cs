using POC.Identity.Domain;
using System.Threading.Tasks;

namespace POC.Identity.Contracts
{
    public interface ICredentialValidator
    {
        Task<CredentialValidationResult> Validate(CredentialType credentialType, string value);
    }
}
