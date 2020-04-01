using POC.Common;
using POC.Configuration.DI.Internal;
using System;
using System.Reflection;
using Unity;

namespace POC.Configuration.DI
{
    public class ContainerConfigurator
    {
        public static IContainer GetEmpty()
        {
            return new UnityContainerImpl(new UnityContainer());
        }

        public static void ConfigureFrom(Assembly assembly, IContainer container)
        {
            var containerConfiguratorType = assembly.GetTypeOf<IContainerConfigurator>();

            if (containerConfiguratorType == null)
            {
                return;
            }

            var configurator = (IContainerConfigurator)Activator.CreateInstance(containerConfiguratorType);

            configurator.Configure(container);
        }
    }
}
