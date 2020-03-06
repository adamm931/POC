namespace POC.Identity.Web.Models
{
    public class UserSignupModel : BaseModel
    {
        public static UserSignupModel Empty = new UserSignupModel();

        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public bool PasswordsMismatch => Password != ConfirmPassword;
    }
}