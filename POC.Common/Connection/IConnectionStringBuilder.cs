using POC.Common.Connection;

namespace POC.Common
{
    public interface IConnectionStringBuilder
    {
        IConnectionStringBuilder AddVariables(IConnectionStringVariables variables);

        IConnectionStringBuilder SetTemplates(IConnectionStringTemplate template);

        IConnectionString Build();
    }
}
