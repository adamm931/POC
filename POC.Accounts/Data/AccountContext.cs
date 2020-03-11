using POC.Accounts.Domain;
using POC.Common.Connection;
using System;
using System.Data.Entity;

namespace POC.Accounts.Data
{
    public class AccountContext : DbContext
    {
        #region Collections 

        public DbSet<Account> Accounts { get; set; }

        public DbSet<AccountLogin> AccountLogins { get; set; }

        #endregion

        #region Constructor(s)

        public AccountContext() : base(GetConnectionString())
        {
            Database.SetInitializer(new AccountContext.Seeder());
        }

        #endregion

        #region Connection string

        public static string GetConnectionString()
        {
            var connectionString = ConnectionStringGenerator
                .GetConnectionString("AccountsDb")
                .Value;

            return connectionString;
        }

        #endregion

        #region OnModelConfiguring

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        }

        #endregion

        #region Initializer

        public class Seeder : CreateDatabaseIfNotExists<AccountContext>
        {
            protected override void Seed(AccountContext context)
            {
                var account_1_address = new AccountAddress("Nade Tomic", "Nis", "18000", "Mediana", "0604240737", "adam.milenkovic.993@gmail.com");
                var account_2_address = new AccountAddress("Nade Tomic", "Nis", "18000", "Mediana", "0606240737", "petarde.raketice.993@gmail.com");

                var account_1_login = new AccountLogin("Adam");
                var account_2_login = new AccountLogin("Adam123");

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

        #endregion
    }
}
