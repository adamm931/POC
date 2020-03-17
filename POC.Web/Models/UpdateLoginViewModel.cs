using POC.Web.Validation.Attributes;
using POC.Web.Validation.Resources;
using System.ComponentModel.DataAnnotations;

namespace POC.Web.Models
{
    public class UpdateLoginViewModel
    {
        [PocRequired(nameof(Username))]
        [PocUniqueUsename]
        public string Username { get; set; }

        [PocRequired(nameof(Password))]
        [PocPassword]
        [PocPasswordMatch(nameof(ConfirmPassword))]
        public string Password { get; set; }

        [Display(Name = nameof(ConfirmPassword), ResourceType = typeof(DisplayNames))]
        [PocRequired(nameof(ConfirmPassword))]
        [PocPassword]
        public string ConfirmPassword { get; set; }
    }
}