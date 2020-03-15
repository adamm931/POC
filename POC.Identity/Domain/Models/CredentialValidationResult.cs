using POC.Identity.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace POC.Identity.Domain.Models
{
    public class CredentialValidationResult
    {
        private readonly List<string> _validationError = new List<string>();

        public bool IsValid => !ValidationErrors.Any();

        public CredentialType CredentailType { get; }

        public IReadOnlyList<string> ValidationErrors => _validationError.AsReadOnly();

        public CredentialValidationResult(CredentialType credentailType)
        {
            CredentailType = credentailType;
        }

        public void AddValidationError(string error)
        {
            _validationError.Add(error);
        }

        public override string ToString()
        {
            var header = $"Validation failed for {CredentailType}";
            _validationError.Insert(0, header);

            return string.Join(". ", ValidationErrors);
        }
    }
}
