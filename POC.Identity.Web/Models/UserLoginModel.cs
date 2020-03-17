using POC.Web.Validation.Attributes;

namespace POC.Identity.Web.Models
{
    public class UserLoginModel
    {
        public static UserLoginModel Empty => new UserLoginModel();

        [PocCheckCredentials(nameof(Password))]
        [PocUsername]
        [PocRequired(nameof(Username))]
        public string Username { get; set; }

        [PocPassword]
        [PocRequired(nameof(Password))]
        public string Password { get; set; }
    }
}