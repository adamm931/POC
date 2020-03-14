using System;
using System.Collections.Generic;
using System.Linq;

namespace POC.Identity.Domain
{
    public class CredentialValidationResult
    {
        private readonly List<string> _validationError = new List<string>();

        public bool IsValid => !ValidationErrors.Any();

        public IReadOnlyList<string> ValidationErrors => _validationError.AsReadOnly();

        public void AddValidationError(string error)
        {
            _validationError.Add(error);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, ValidationErrors);
        }
    }
}
