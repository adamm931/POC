using POC.Web.Validation.Attributes;
using POC.Web.Validation.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace POC.Web.Models
{
    public class AccountHeaderViewModel
    {
        [Display(Name = nameof(FirstName), ResourceType = typeof(DisplayNames))]
        [PocRequired(nameof(FirstName))]
        public string FirstName { get; set; }

        [Display(Name = nameof(LastName), ResourceType = typeof(DisplayNames))]
        [PocRequired(nameof(LastName))]
        public string LastName { get; set; }

        [Display(Name = nameof(MiddleName), ResourceType = typeof(DisplayNames))]
        [PocRequired(nameof(MiddleName))]
        public string MiddleName { get; set; }

        [PocRequired(nameof(Gender))]
        public string Gender { get; set; }

        [Display(Name = nameof(BirthDay), ResourceType = typeof(DisplayNames))]
        [PocRequired(nameof(BirthDay))]
        public DateTime BirthDay { get; set; }
    }
}