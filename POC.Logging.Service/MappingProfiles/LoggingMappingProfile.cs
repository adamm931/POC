using AutoMapper;
using POC.Logging.Domain;
using POC.Logging.Service.UseCases.ListLogEntries;

namespace POC.Logging.Service.MappingProfiles
{
    public class LoggingMappingProfile : Profile
    {
        public LoggingMappingProfile()
        {
            CreateMap<LogEntry, ListLogEntriesServiceResponse.Item>()
                .ForMember(dst => dst.Level, opts => opts.MapFrom(src => src.Level.Value));
        }
    }
}