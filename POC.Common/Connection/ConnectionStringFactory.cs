using POC.Common.Enviroment;

namespace POC.Common.Connection
{
    public class ConnectionStringFactory
    {
        public static IConnectionString GetMongoConnnectionString(string database)
        {
            var builder = new ConnectionStringBuilder()
                .SetTemplates(new MongoConnectionStringTemplate())
                .AddVariables(new ConnectionStringVariables(
                    EnviromentConnectionStringVariable.Host(EnviromentVariables.MongoHost),
                    EnviromentConnectionStringVariable.Port(EnviromentVariables.MongoPort),
                    InlineConnectionStringVariable.DbName(database)));

            return builder.Build();
        }

        public static IConnectionString GetSqlConnectionString(string database)
        {
            var builder = new ConnectionStringBuilder()
                .SetTemplates(new MongoConnectionStringTemplate())
                .AddVariables(new ConnectionStringVariables(
                    EnviromentConnectionStringVariable.Host(EnviromentVariables.DbHost),
                    EnviromentConnectionStringVariable.Port(EnviromentVariables.DbPort),
                    EnviromentConnectionStringVariable.Password(EnviromentVariables.DbPassword),
                    InlineConnectionStringVariable.User("sa"),
                    InlineConnectionStringVariable.DbName(database)));

            return builder.Build();
        }
    }
}
