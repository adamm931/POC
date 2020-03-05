namespace POC.Common
{
    public interface IConnectionStringBuilder
    {
        IConnectionStringBuilder SetHost(IConnectionStringVariable host);

        IConnectionStringBuilder SetPort(IConnectionStringVariable port);

        IConnectionStringBuilder SetDbName(IConnectionStringVariable dbName);

        IConnectionStringBuilder SetCredentials(IConnectionStringVariable username, IConnectionStringVariable password);

        IConnectionString Build();
    }
}
