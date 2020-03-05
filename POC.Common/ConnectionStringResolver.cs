namespace POC.Common
{
    public class ConnectionStringResolver
    {
        private readonly IConnectionStringBuilder _builder;

        private readonly IConnectionStringVariables _variables;

        public ConnectionStringResolver(IConnectionStringBuilder builder, IConnectionStringVariables variables)
        {
            _builder = builder;
            _variables = variables;
        }

        private ConnectionStringResolver() { }

        public IConnectionString GetConnectionString()
        {
            var connectionString = _builder
                   .SetHost(_variables.GetVariable(ConnectionStringVariables.Host))
                   .SetPort(_variables.GetVariable(ConnectionStringVariables.Port))
                   .SetDbName(_variables.GetVariable(ConnectionStringVariables.DbName))
                   .SetCredentials(
                            _variables.GetVariable(ConnectionStringVariables.User),
                            _variables.GetVariable(ConnectionStringVariables.Password)
                            )
                   .Build();


            return connectionString;
        }
    }
}
