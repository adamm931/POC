namespace POC.Common.Connection
{
    public interface IConnectionStringTemplate
    {
        string Template { get; }

        IConnectionStringTemplate Replace(IConnectionStringVariable variable);
    }

    public class ConnectionStringTemplate : IConnectionStringTemplate
    {
        public ConnectionStringTemplate(string template)
        {
            Template = template;
        }

        public string Template { get; }

        public IConnectionStringTemplate Replace(IConnectionStringVariable variable)
        {
            if (Template.IndexOf(variable.Name) >= 0)
            {
                return new ConnectionStringTemplate(Template.Replace(variable.Name, variable.Value));
            }

            return new ConnectionStringTemplate(Template);
        }
    }
}
