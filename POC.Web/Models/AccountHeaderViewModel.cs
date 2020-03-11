using System;
using System.ComponentModel.DataAnnotations;

namespace POC.Web.Models
{
    public class AccountHeaderViewModel
    {
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Middle name")]
        public string MiddleName { get; set; }

        public string Gender { get; set; }

        public DateTime BirthDay { get; set; }
    }
}