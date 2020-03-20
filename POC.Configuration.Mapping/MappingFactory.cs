using AutoMapper;
using POC.Common;
using System.Linq;
using System.Reflection;

namespace POC.Configuration.Mapping
{
    public class MappingFactory
    {
        public static IMapping CreateMapper(Assembly assembly)
        {
            var profiles = assembly
                .GetInstancesOf<Profile>()
                .ToArray();

            var mapper = new MapperConfiguration(config => config.AddProfiles(profiles))
                .CreateMapper();

            return new Mapping(mapper);
        }
    }
}
