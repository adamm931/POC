using POC.Common.Mapper;
using POC.Configuration.DI;
using POC.Logging.Contracts;
using POC.Logging.Data;
using POC.Logging.Service.MappingProfiles;

namespace POC.Logging.Service.Configuration
{
    public class LoggingContainerConfigurator : IContainerConfigurator
    {
        public void Configure(IContainer container)
        {
            container.RegisterInstance<ILoggingContext>(new LoggingContext());
            container.RegisterInstance(Mapping.Create(new LoggingMappingProfile()));
        }
    }
}