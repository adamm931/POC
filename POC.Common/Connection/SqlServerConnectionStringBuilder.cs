namespace POC.Common.Connection
{
    public class SqlServerConnectionStringBuilder : IConnectionStringBuilder
    {
        private const string _template = "Server=host,port;Database=dbName;User ID=user;Password=password";

        private IConnectionStringVariable _user;
        private IConnectionStringVariable _password;
        private IConnectionStringVariable _dbName;
        private IConnectionStringVariable _host;
        private IConnectionStringVariable _port;

        public IConnectionString Build()
        {
            var value = _template
                .Replace("host", _host.Value)
                .Replace("port", _port.Value)
                .Replace("dbName", _dbName.Value)
                .Replace("user", _user.Value)
                .Replace("password", _password.Value);

            return new ConnectionString(value);
        }

        public IConnectionStringBuilder SetCredentials(IConnectionStringVariable user, IConnectionStringVariable password)
        {
            _user = user;
            _password = password;

            return this;
        }

        public IConnectionStringBuilder SetDbName(IConnectionStringVariable dbName)
        {
            _dbName = dbName;

            return this;
        }

        public IConnectionStringBuilder SetHost(IConnectionStringVariable host)
        {
            _host = host;

            return this;
        }

        public IConnectionStringBuilder SetPort(IConnectionStringVariable port)
        {
            _port = port;

            return this;
        }
    }
}
