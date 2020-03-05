using POC.Service.Contracts;
using System.Configuration;

namespace POC.Service.Data
{
    public class TodosProviderResolver
    {
        public static ITodosProvider GetProvider()
        {
            var type = ConfigurationManager.AppSettings["UseFakeProvider"];

            bool.TryParse(type, out var useFake);

            return useFake
                ? new InMemoryTodosProvider()
                : (ITodosProvider)TodoItemContext.Create();
        }

        public static ITodosProvider GetAsyncProvider()
        {
            var type = ConfigurationManager.AppSettings["UseFakeProvider"];

            bool.TryParse(type, out var useFake);

            return useFake
                ? new InMemoryTodosProvider()
                : (ITodosProvider)TodoItemContext.Create();
        }
    }
}