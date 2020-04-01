using System;

namespace POC.Configuration.DI
{
    public static class ContainerProvider
    {
        public static IContainer Container { get; private set; }

        static ContainerProvider()
        {
            Container = Container ?? ContainerConfigurator.GetEmpty();

            Container.RegisterInstance(Container);
        }

        public static void ApplyConfigurationFromAssembly(Type assemblyType)
        {
            ContainerConfigurator.ConfigureFrom(assemblyType.Assembly, Container);
        }
    }
}
