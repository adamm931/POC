using System.ComponentModel.DataAnnotations;

namespace POC.Identity.Web.Models
{
    public class UserLoginModel
    {
        public static UserLoginModel Empty = new UserLoginModel();

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}