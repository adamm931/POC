using POC.Common.Connection;
using POC.Configuration.DI;
using POC.Configuration.Mapping;
using POC.Todos.Contracts;
using POC.Todos.Data;

namespace POC.Todos.Service.DI
{
    public class TodoServiceContainerConfigurator : IContainerConfigurator
    {
        public void Configure(IContainer container)
        {
            container.RegisterInstance(ConnectionStringFactory.GetSqlConnectionString("Todos"));
            container.Register<ITodoContext, TodoContext>();
            container.RegisterMapping(GetType().Assembly);
        }
    }
}