﻿using POC.Identity.Web.Authentication.Attributes;
using System.ComponentModel.DataAnnotations;

namespace POC.Identity.Web.Models
{
    public class UserSignupModel
    {
        public static UserSignupModel Empty = new UserSignupModel();

        [Required, UniqueUsename]
        public string Username { get; set; }

        [Required, Password, Compare(nameof(ConfirmPassword), ErrorMessage = "Password don't match")]
        public string Password { get; set; }

        [Required, Password]
        public string ConfirmPassword { get; set; }
    }
}