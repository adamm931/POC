using POC.Common.Enviroment;

namespace POC.Common.Connection
{
    public class ConnectionStringGenerator
    {
        public static IConnectionString GetConnectionString(string database)
        {
            var builder = new SqlServerConnectionStringBuilder();

            var variables = new ConnectionStringVariables(
                EnviromentConnectionStringVariable.Host(EnviromentVariables.DbHost),
                EnviromentConnectionStringVariable.Port(EnviromentVariables.DbPort),
                EnviromentConnectionStringVariable.Password(EnviromentVariables.DbPassword),
                InlineConnectionStringVariable.User("sa"),
                InlineConnectionStringVariable.DbName(database/*"AccountsDb"*/));

            var connectionString = new ConnectionStringResolver(builder, variables)
                .GetConnectionString();

            return connectionString;
        }
    }
}
