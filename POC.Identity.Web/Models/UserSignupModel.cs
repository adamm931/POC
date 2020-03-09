using System.ComponentModel.DataAnnotations;

namespace POC.Identity.Web.Models
{
    public class UserSignupModel
    {
        public static UserSignupModel Empty = new UserSignupModel();

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        public bool PasswordsMismatch => Password != ConfirmPassword;
    }
}