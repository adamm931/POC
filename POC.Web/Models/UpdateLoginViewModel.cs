using POC.Identity.Web.Authentication.Attributes;
using System.ComponentModel.DataAnnotations;

namespace POC.Web.Models
{
    public class UpdateLoginViewModel
    {
        [Required, UniqueUsename]
        public string Username { get; set; }

        [Required, Display(Name = "New password"), Password, Compare(nameof(ConfirmPassword), ErrorMessage = "Passwords don't match")]
        public string Password { get; set; }

        [Required, Password, Display(Name = "Confirm new password")]
        public string ConfirmPassword { get; set; }
    }
}