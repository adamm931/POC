using POC.Common.Connection;
using POC.Identity.Domain.Entities;
using POC.Identity.Domain.Enums;
using System.Data.Entity;
using static POC.Identity.Domain.Entities.CredentialRule;

namespace POC.Identity.Data
{
    public class IdentityContext : DbContext
    {
        #region Collections

        public DbSet<UserLogin> UserLogins { get; set; }

        public DbSet<CredentialRule> CredentialRules { get; set; }

        #endregion

        #region Constructor(s)

        public IdentityContext() : base(GetConnectionString())
        {
            Database.SetInitializer(new IdentityContext.Seeder());
        }

        #endregion

        #region OnModelConfiguring

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region Connection string

        public static string GetConnectionString()
        {
            var connectionString = ConnectionStringGenerator.GetConnectionString("Identity");

            return connectionString.Value;
        }

        #endregion

        #region Initializer

        public class Seeder : CreateDatabaseIfNotExists<IdentityContext>
        {
            protected override void Seed(IdentityContext context)
            {
                var passwordRules = new CredentialRule[]
                {
                    new MinimumLenghtRule(CredentialType.Password,
                        new CredentialRuleAttribute(CredentialRuleType.MinimumLenght, "12")
                        ),
                    new RequireAlphaNumericCharathersRule(CredentialType.Password),
                    new RequireSpecialCharathersRule(CredentialType.Password),
                };

                var usernameRules = new CredentialRule[]
                {
                    new MinimumLenghtRule(CredentialType.Username,
                        new CredentialRuleAttribute(CredentialRuleType.MinimumLenght, "8")
                        ),
                    new RequireAlphaNumericCharathersRule(CredentialType.Username),
                };

                context.CredentialRules.AddRange(passwordRules);
                context.CredentialRules.AddRange(usernameRules);

                context.UserLogins.AddRange(new[] {
                    new UserLogin("Adam1993", "Password1234!"),
                    new UserLogin("Mario1993", "Password1234!"),
                    new UserLogin("Neni1996", "Password1234!")
                    });
            }
        }

        #endregion
    }
}
