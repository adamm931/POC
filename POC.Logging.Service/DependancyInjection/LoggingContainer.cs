using POC.Common.Mapper;
using POC.Logging.Contracts;
using POC.Logging.Data;
using POC.Logging.Service.MappingProfiles;
using Unity;

namespace POC.Logging.Service.DependancyInjection
{
    public class LoggingContainer : UnityContainer
    {
        private static LoggingContainer _instance = null;

        public static LoggingContainer Instance => _instance = (_instance ?? new LoggingContainer());

        private LoggingContainer()
        {
            Configure(this);
        }

        private static void Configure(IUnityContainer container)
        {
            container.RegisterInstance<ILoggingContext>(new LoggingContext());
            container.RegisterInstance(Mapping.Create(new LoggingMappingProfile()));
        }

        public static void Configure()
        {
            if (_instance != null)
            {
                return;
            }

            _instance = new LoggingContainer();

            Configure(_instance);
        }
    }
}