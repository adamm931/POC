using POC.Common;
using POC.Identity.Data.Entities;
using System.Data.Entity;

namespace POC.Identity.Data
{
    public class TodoIdentityContext : DbContext
    {
        #region Collections

        public DbSet<UserLogin> UserLogins { get; set; }

        #endregion

        #region Constructor(s)

        public TodoIdentityContext() : base(GetConnectionString())
        {
            Database.SetInitializer(new TodoIdentityContext.Seeder());
        }

        #endregion

        #region Connection string
        public static string GetConnectionString()
        {
            var builder = new SqlServerConnectionStringBuilder();

            var variables = new ConnectionStringVariables(
                EnviromentConnectionStringVariable.Host("TodoDbHost"),
                EnviromentConnectionStringVariable.Port("TodoDbPort"),
                EnviromentConnectionStringVariable.Password("TodoDbSaPassword"),
                InlineConnectionStringVariable.User("sa"),
                InlineConnectionStringVariable.DbName("TodoIdentityDb"));

            var connectionString = new ConnectionStringResolver(builder, variables)
                .GetConnectionString();

            return connectionString.Value;
        }

        #endregion

        #region Initializer

        public class Seeder : CreateDatabaseIfNotExists<TodoIdentityContext>
        {
            protected override void Seed(TodoIdentityContext context)
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
