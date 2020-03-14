namespace POC.Identity.Domain
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
    }
}
