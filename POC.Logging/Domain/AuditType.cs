namespace POC.Logging.Domain
{
    public class AuditType
    {
        public static AuditType UserSignuped = new AuditType(nameof(UserSignuped));

        public static AuditType UserLoginedIn = new AuditType(nameof(UserLoginedIn));

        public static AuditType UserUpdatedLogin = new AuditType(nameof(UserUpdatedLogin));

        public static AuditType AccountUpdated = new AuditType(nameof(AccountUpdated));

        public static AuditType TodoAdded = new AuditType(nameof(TodoAdded));

        public static AuditType TodoUpdated = new AuditType(nameof(TodoUpdated));

        public static AuditType TodoDeleted = new AuditType(nameof(TodoDeleted));

        public AuditType(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}
