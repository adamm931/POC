using POC.Service.Contracts;
using System.Configuration;

namespace POC.Service.Managers
{
    public class TodoManagerFactory
    {
        public static ITodoManager GetManager()
        {
            var type = ConfigurationManager.AppSettings["UseFakeProvider"];

            bool.TryParse(type, out var useFake);

            return useFake
                ? new InMemoryTodosManager()
                : (ITodoManager)new TodosManager();
        }
    }
}