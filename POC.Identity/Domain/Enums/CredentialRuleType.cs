namespace POC.Identity.Domain.Enums
{
    public class CredentialRuleType
    {
        public static CredentialRuleType MinimumLenght = new CredentialRuleType(nameof(MinimumLenght));

        public static CredentialRuleType RequireAlphaNumeric = new CredentialRuleType(nameof(RequireAlphaNumeric));

        public static CredentialRuleType RequireSpecialCharater = new CredentialRuleType(nameof(RequireSpecialCharater));

        private CredentialRuleType(string value)
        {
            Value = value;
        }

        private CredentialRuleType() { }

        public string Value { get; private set; }

        public static bool operator ==(CredentialRuleType left, CredentialRuleType right)
        {
            return left.Value == right.Value;
        }

        public static bool operator !=(CredentialRuleType left, CredentialRuleType right)
        {
            return !(left.Value == right.Value);
        }

        public static implicit operator CredentialRuleType(string type)
        {
            return new CredentialRuleType(type);
        }

        public static implicit operator string(CredentialRuleType type)
        {
            return type.Value;
        }

        public static CredentialRuleType Parse(string type)
        {
            return new CredentialRuleType(type);
        }
    }
}
