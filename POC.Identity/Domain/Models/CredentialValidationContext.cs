using POC.Identity.Domain.Enums;

namespace POC.Identity.Domain.Models
{
    public class CredentialValidationContext
    {
        public string Value { get; }

        public CredentialType CredentialType { get; }

        public CredentialValidationContext(string value, CredentialType credentialType)
        {
            Value = value;
            CredentialType = credentialType;
        }
    }
}
