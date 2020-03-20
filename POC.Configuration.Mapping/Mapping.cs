using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace POC.Configuration.Mapping
{
    public class Mapping : IMapping
    {
        private readonly IMapper _mapper;

        private Mapping(IEnumerable<Profile> profiles)
        {
            _mapper = new MapperConfiguration(config => config.AddProfiles(profiles))
                .CreateMapper();
        }

        public Mapping(IMapper mapper)
        {
            _mapper = mapper;
        }

        public static IMapping Create(params Profile[] profiles)
        {
            return new Mapping(profiles);
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
