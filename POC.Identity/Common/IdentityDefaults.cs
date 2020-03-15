namespace POC.Identity.Common
{
    public class IdentityDefaults
    {
        public class RegularExpressions
        {
            public const string Username = "^[a-zA-Z0-9].*$";

            public const string Password = "^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).*$";

            public const string Master = "^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).*$";
        }
    }
}
