using POC.Common.Enviroment;

namespace POC.Common.Connection
{
    public interface IConnectionStringVariable
    {
        string Value { get; }

        string Name { get; }
    }

    public class InlineConnectionStringVariable : IConnectionStringVariable
    {
        public static IConnectionStringVariable Host(string value) => new InlineConnectionStringVariable(ConnectionStringVariables.Host, value);

        public static IConnectionStringVariable Port(string value) => new InlineConnectionStringVariable(ConnectionStringVariables.Port, value);

        public static IConnectionStringVariable DbName(string value) => new InlineConnectionStringVariable(ConnectionStringVariables.DbName, value);

        public static IConnectionStringVariable User(string value) => new InlineConnectionStringVariable(ConnectionStringVariables.User, value);

        public static IConnectionStringVariable Password(string value) => new InlineConnectionStringVariable(ConnectionStringVariables.Password, value);


        private InlineConnectionStringVariable(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Value { get; }

        public string Name { get; }
    }

    public class EnviromentConnectionStringVariable : IConnectionStringVariable
    {
        public static IConnectionStringVariable Host(string enviromentVariableName) => new EnviromentConnectionStringVariable(ConnectionStringVariables.Host, enviromentVariableName);

        public static IConnectionStringVariable Port(string enviromentVariableName) => new EnviromentConnectionStringVariable(ConnectionStringVariables.Port, enviromentVariableName);

        public static IConnectionStringVariable DbName(string enviromentVariableName) => new EnviromentConnectionStringVariable(ConnectionStringVariables.DbName, enviromentVariableName);

        public static IConnectionStringVariable User(string enviromentVariableName) => new EnviromentConnectionStringVariable(ConnectionStringVariables.User, enviromentVariableName);

        public static IConnectionStringVariable Password(string enviromentVariableName) => new EnviromentConnectionStringVariable(ConnectionStringVariables.Password, enviromentVariableName);

        public EnviromentConnectionStringVariable(string name, string enviromentVariableName)
        {
            Name = name;
            Value = EnviromentVariablesFetcher.GetVaraiable(enviromentVariableName);
        }

        public string Value { get; }

        public string Name { get; }
    }
}
