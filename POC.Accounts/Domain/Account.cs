using POC.Common.Domain;
using System;

namespace POC.Accounts.Domain
{
    public class Account : Entity
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string MiddleName { get; private set; }

        public Gender Gender { get; private set; }

        public DateTime? BirthDay { get; private set; }

        public AccountAddress Address { get; private set; }

        public AccountLogin Login { get; private set; }

        public Account(
            string firstName,
            string lastName,
            string middleName,
            Gender gender,
            DateTime birthDay,
            AccountAddress address,
            AccountLogin login)
        {
            UpdateHeader(firstName, lastName, middleName, birthDay, gender);

            Address = address;
            Login = login;
        }

        public static Account Empty()
        {
            return new Account
            {
                Gender = Gender.Undefined,
                Address = new AccountAddress()
            };
        }

        internal Account()
        {
        }

        public void UpdateHeader(string firstName, string lastName, string middleName, DateTime birthDay, Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            BirthDay = birthDay;
            Gender = gender;
        }

        public void UpdatetAddress(string street, string city, string zipCode, string region, string phone, string email)
        {
            Address.UpdateAddress(street, city, zipCode, region, phone, email);
        }

        public void UpdateLogin(string username)
        {
            Login.UpdateUsername(username);
        }
    }
}
