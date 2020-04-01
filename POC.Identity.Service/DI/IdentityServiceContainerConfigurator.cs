using POC.Common.Connection;
using POC.Configuration.DI;
using POC.Configuration.Mapping;
using POC.Identity.Contracts;
using POC.Identity.Data;
using POC.Identity.Internal;
using POC.RabbitMQ.DI;
using System.Data.Entity;

namespace POC.Identity.Service.DI
{
    public class IdentityServiceContainerConfigurator : IContainerConfigurator
    {
        public void Configure(IContainer container)
        {
            container.RegisterMapping(GetType().Assembly);
            container.Register<IIdentityContext, IdentityContext>();
            container.RegisterInstance(ConnectionStringFactory.GetSqlConnectionString("PocIdentity"));
            container.Register<ICredentialRequirmentValidator, CredentialRequirmentValidator>();
            container.Register<IDatabaseInitializer<IdentityContext>, IdentityContextSeeder>();
            container.RegisterRabbitMQ();
        }
    }
}