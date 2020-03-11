namespace POC.Common.Connection
{
    internal class ConnectionString : IConnectionString
    {
        public ConnectionString(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
    }

    public interface IConnectionString
    {
        string Value { get; }
    }
}
