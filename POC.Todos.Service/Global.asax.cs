using POC.Configuration.DI;
using System;
using System.Web;

namespace POC.Todos.Service
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ContainerProvider.ApplyConfigurationFromAssembly(typeof(Global));
        }
    }
}