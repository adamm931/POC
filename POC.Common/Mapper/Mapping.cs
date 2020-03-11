using AutoMapper;
using System.Collections.Generic;

namespace POC.Common.Mapper
{
    public class Mapping
    {
        private readonly IMapper _mapper;

        private Mapping(IEnumerable<Profile> profiles)
        {
            _mapper = new MapperConfiguration(config => config.AddProfiles(profiles))
                .CreateMapper();
        }

        public static Mapping Create(params Profile[] profiles)
        {
            return new Mapping(profiles);
        }

        public static Mapping Create()
        {
            return new Mapping(new List<Profile>());
        }

        public TDestination Map<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }
    }
}
