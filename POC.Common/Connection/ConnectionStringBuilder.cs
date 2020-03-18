using System.Linq;

namespace POC.Common.Connection
{
    public class ConnectionStringBuilder : IConnectionStringBuilder
    {
        private IConnectionStringTemplate _template;

        private IConnectionStringVariables _variables;

        public IConnectionStringBuilder AddVariables(IConnectionStringVariables variables)
        {
            _variables = variables;

            return this;
        }

        public IConnectionStringBuilder SetTemplates(IConnectionStringTemplate template)
        {
            _template = template;

            return this;
        }

        public IConnectionString Build()
        {
            var value = _variables
                .Aggregate(_template, (template, variable) => template = template.Replace(variable))
                .Template;

            return new ConnectionString(value);
        }
    }
}
