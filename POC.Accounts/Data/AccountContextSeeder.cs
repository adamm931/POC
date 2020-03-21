using POC.Accounts.Domain;
using System;
using System.Data.Entity;

namespace POC.Accounts.Data
{
    public class AccountContextSeeder : CreateDatabaseIfNotExists<AccountContext>
    {
        protected override void Seed(AccountContext context)
        {
            var account_1_address = new AccountAddress("Nade Tomic", "Nis", "18000", "Mediana", "0604240737", "adam.milenkovic.993@gmail.com");
            var account_2_address = new AccountAddress("Nade Tomic", "Nis", "18000", "Mediana", "0606240737", "petarde.raketice.993@gmail.com");

            var account_1_login = new AccountLogin("Adam1993");
            var account_2_login = new AccountLogin("Mario1993");

            var account_1 = new Account(
                "Adam", "Milenkovic", "Dejan", Gender.Male, new DateTime(1993, 9, 5, 15, 24, 31, DateTimeKind.Utc),
                account_1_address,
                account_1_login);

            var account_2 = new Account(
                "Mario", "Milenkovic", "Dejan", Gender.Male, new DateTime(1993, 9, 5, 15, 29, 31, DateTimeKind.Utc),
                account_2_address,
                account_2_login);

            context.Accounts.AddRange(new[] { account_1, account_2 });
        }
    }
}
