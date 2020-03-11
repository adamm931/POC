using POC.Common.Connection;
using POC.Identity.Domain;
using System.Data.Entity;

namespace POC.Identity.Data
{
    public class IdentityContext : DbContext
    {
        #region Collections

        public DbSet<UserLogin> UserLogins { get; set; }

        #endregion

        #region Constructor(s)

        public IdentityContext() : base(GetConnectionString())
        {
            Database.SetInitializer(new IdentityContext.Seeder());
        }

        #endregion

        #region Connection string

        public static string GetConnectionString()
        {
            var connectionString = ConnectionStringGenerator.GetConnectionString("TodoIdentityDb");

            return connectionString.Value;
        }

        #endregion

        #region Initializer

        public class Seeder : CreateDatabaseIfNotExists<IdentityContext>
        {
            protected override void Seed(IdentityContext context)
            {
                context.UserLogins.AddRange(new[] {
                    UserLogin.Create("Adam", "Test1234"),
                    UserLogin.Create("Adam123", "09051993"),
                    UserLogin.Create("Adam0905", "Test0905")
                    });
            }
        }

        #endregion
    }
}
