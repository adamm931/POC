using POC.Identity.Domain;
using System;

namespace POC.Identity.Exceptions
{
    public class CredentialValidationException : Exception
    {
        public CredentialValidationException(string message) : base(message)
        {
        }

        public CredentialValidationException(CredentialValidationResult validationResult)
            : base(validationResult.ToString())
        {
        }
    }
}
