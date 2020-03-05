namespace POC.Identity.Web.Models
{
    public class UserLoginModel
    {
        public static UserLoginModel Empty = new UserLoginModel();

        public string Username { get; set; }

        public string Password { get; set; }

        public bool FailedLogin { get; set; }

        public string FailedLoginMessage { get; set; }
    }
}