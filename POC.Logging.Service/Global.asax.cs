using System;
using System.Web;

namespace POC.Logging.Service
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // LoggingContainer.Configure();
        }
    }
}