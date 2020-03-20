namespace POC.Common.Connection
{
    public class SqlServerConnectionStringTemplate : ConnectionStringTemplate
    {
        public SqlServerConnectionStringTemplate() : base(GetTemplate())
        {
        }

        public static string GetTemplate() => $"Server=${ConnectionStringVariables.Host}$,${ConnectionStringVariables.Port}$;" +
            $"Database=${ConnectionStringVariables.DbName}$;" +
            $"User ID=${ConnectionStringVariables.User}$;" +
            $"Password=${ConnectionStringVariables.Password}$";
    }
}
