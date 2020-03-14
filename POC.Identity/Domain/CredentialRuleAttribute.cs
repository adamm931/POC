using POC.Common.Domain;
using System;

namespace POC.Identity.Domain
{
    public class CredentialRuleAttribute : Entity
    {
        public CredentialRuleAttribute(string name, string value)
        {
            Name = name;
            Value = value;
            IsEnabled = true;
        }

        public string Name { get; private set; }

        public string Value { get; private set; }

        public bool IsEnabled { get; private set; }

        public Guid CredentialRuleId { get; private set; }

        public CredentialRule CredentialRule { get; private set; }
    }
}
