using POC.Configuration.DI;
using System.Reflection;

namespace POC.Configuration.Mapping
{
    public static class Extensions
    {
        public static void RegisterMapping(this IContainer container, Assembly assembly)
        {
            var mapper = MappingFactory.CreateMapper(assembly);

            container.RegisterInstance(mapper);
        }
    }
}
