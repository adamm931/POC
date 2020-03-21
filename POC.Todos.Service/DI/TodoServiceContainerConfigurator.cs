using POC.Common.Connection;
using POC.Configuration.DI;
using POC.Configuration.Mapping;
using POC.Todos.Contracts;
using POC.Todos.Data;
using System.Data.Entity;

namespace POC.Todos.Service.DI
{
    public class TodoServiceContainerConfigurator : IContainerConfigurator
    {
        public void Configure(IContainer container)
        {
            container.RegisterInstance(ConnectionStringFactory.GetSqlConnectionString("PocTodos"));
            container.Register<ITodoContext, TodoContext>();
            container.Register<IDatabaseInitializer<TodoContext>, TodoContextSeeder>();
            container.RegisterMapping(GetType().Assembly);
        }
    }
}