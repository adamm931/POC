using POC.Configuration.DI.Internal;
using System;
using System.Linq;
using System.Reflection;
using Unity;

namespace POC.Configuration.DI
{
    public class ContainerFactory
    {
        public static IContainer GetContainer(Assembly assembly)
        {
            var containerConfiguratorType = assembly
                .GetExportedTypes()
                .FirstOrDefault(type => typeof(IContainerConfigurator).IsAssignableFrom(type));

            var container = new UnityContainerImpl(new UnityContainer());

            if (containerConfiguratorType == null)
            {
                return container;
            }

            var configurator = Activator.CreateInstance(containerConfiguratorType) as IContainerConfigurator;

            configurator.Configure(container);

            return container;
        }
    }
}
