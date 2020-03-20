using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace POC.Common.Mapper
{
    public class Mapping : IMapping
    {
        private readonly IMapper _mapper;

        private Mapping(IEnumerable<Profile> profiles)
        {
            _mapper = new MapperConfiguration(config => config.AddProfiles(profiles))
                .CreateMapper();
        }

        public static IMapping Create(params Profile[] profiles)
        {
            return new Mapping(profiles);
        }

        public static IMapping Create()
        {
            return new Mapping(new List<Profile>());
        }

        public TDestination Map<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }

        public TDestination Map<TDestination>(params object[] sources)
        {
            var initial = _mapper.Map<TDestination>(sources.First());

            return sources
                .Skip(1)
                .Aggregate(initial, (current, next) => _mapper.Map(next, current));
        }
    }
}
