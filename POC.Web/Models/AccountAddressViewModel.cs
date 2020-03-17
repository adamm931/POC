using POC.Web.Validation.Attributes;
using POC.Web.Validation.Resources;
using System.ComponentModel.DataAnnotations;

namespace POC.Web.Models
{
    public class AccountAddressViewModel
    {
        [PocRequired(nameof(Street))]
        public string Street { get; set; }

        [PocRequired(nameof(City))]
        public string City { get; set; }

        [Display(Name = nameof(ZipCode), ResourceType = typeof(DisplayNames))]
        [PocRequired(nameof(City))]
        public string ZipCode { get; set; }

        [PocRequired(nameof(Region))]
        public string Region { get; set; }

        [PocRequired(nameof(Phone))]
        public string Phone { get; set; }

        [PocRequired(nameof(Email))]
        public string Email { get; set; }
    }
}