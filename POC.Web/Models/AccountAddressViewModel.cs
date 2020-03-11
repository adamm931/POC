using System.ComponentModel.DataAnnotations;

namespace POC.Web.Models
{
    public class AccountAddressViewModel
    {
        public string Street { get; set; }

        public string City { get; set; }

        [Display(Name = "Zip code")]
        public string ZipCode { get; set; }

        public string Region { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}