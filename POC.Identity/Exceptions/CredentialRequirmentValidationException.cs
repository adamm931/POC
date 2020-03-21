using POC.Identity.Domain.Models;
using System;

namespace POC.Identity.Exceptions
{
    public class CredentialRequirmentValidationException : Exception
    {
        public CredentialRequirmentValidationException(string message) : base(message)
        {
        }

        public CredentialRequirmentValidationException(CredentialRequirmentValidationResult validationResult)
            : base(validationResult.ToString())
        {
        }
    }
}
