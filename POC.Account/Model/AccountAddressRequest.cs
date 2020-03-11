﻿using System;

namespace POC.Accounts.Model
{
    public class AccountAddressRequest
    {
        public Guid AccountId { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string Region { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
