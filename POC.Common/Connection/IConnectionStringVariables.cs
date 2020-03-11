using System.Linq;

namespace POC.Common.Connection
{
    public interface IConnectionStringVariables
    {
        IConnectionStringVariable GetVariable(string name);
    }

    public class ConnectionStringVariables : IConnectionStringVariables
    {
        public const string Host = "Host";
        public const string Port = "Port";
        public const string DbName = "DbName";
        public const string User = "User";
        public const string Password = "Password";

        private IConnectionStringVariable[] _variables;

        public ConnectionStringVariables(params IConnectionStringVariable[] variables)
        {
            _variables = variables;
        }

        public IConnectionStringVariable GetVariable(string name)
        {
            return _variables.Single(variable => variable.Name == name);
        }
    }
}
