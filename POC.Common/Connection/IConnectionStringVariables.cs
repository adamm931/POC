using System.Collections;
using System.Collections.Generic;

namespace POC.Common.Connection
{
    public interface IConnectionStringVariables : IEnumerable<IConnectionStringVariable>
    {
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

        public IEnumerator<IConnectionStringVariable> GetEnumerator()
        {
            foreach (var variable in _variables)
            {
                yield return variable;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
