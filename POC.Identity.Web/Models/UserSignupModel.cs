using POC.Web.Validation.Attributes;

namespace POC.Identity.Web.Models
{
    public class UserSignupModel
    {
        public static UserSignupModel Empty => new UserSignupModel();

        [PocUniqueUsename]
        [PocRequired(nameof(Username))]
        public string Username { get; set; }

        [PocPasswordMatch(nameof(ConfirmPassword))]
        [PocPassword]
        [PocRequired(nameof(Password))]
        public string Password { get; set; }

        [PocPassword]
        [PocRequired(nameof(ConfirmPassword))]
        public string ConfirmPassword { get; set; }
    }
}