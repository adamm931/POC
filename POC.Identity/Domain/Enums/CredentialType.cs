namespace POC.Identity.Domain.Enums
{
    public class CredentialType
    {
        public static CredentialType Username = new CredentialType(nameof(Username));

        public static CredentialType Password = new CredentialType(nameof(Password));

        private CredentialType(string value)
        {
            Value = value;
        }

        private CredentialType() { }

        public string Value { get; private set; }

        public static bool operator ==(CredentialType left, CredentialType right)
        {
            return left.Value == right.Value;
        }

        public static bool operator !=(CredentialType left, CredentialType right)
        {
            return !(left.Value == right.Value);
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
