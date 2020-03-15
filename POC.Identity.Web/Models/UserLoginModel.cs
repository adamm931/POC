using POC.Identity.Web.Authentication.Attributes;
using System.ComponentModel.DataAnnotations;

namespace POC.Identity.Web.Models
{
    public class UserLoginModel
    {
        public static UserLoginModel Empty = new UserLoginModel();

        [Required, Username]
        public string Username { get; set; }

        [Required, Password]
        public string Password { get; set; }
    }
}