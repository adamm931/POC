namespace POC.Identity.Domain
{
    public class CredentialRuleValidationResult
    {
        public string Message { get; private set; }

        public bool IsValid { get; private set; }

        private CredentialRuleValidationResult() { }

        public static CredentialRuleValidationResult Valid()
        {
            return new CredentialRuleValidationResult
            {
                IsValid = true
            };
        }

        public static CredentialRuleValidationResult Error(string message)
        {
            return new CredentialRuleValidationResult
            {
                IsValid = false,
                Message = message
            };
        }
    }
}
