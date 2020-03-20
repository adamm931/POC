using MongoDB.Driver;
using MongoDB.Driver.Linq;
using POC.Common.Service;
using POC.Configuration.Mapping;
using POC.Logging.Contracts;
using POC.Logging.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.Logging.Service.UseCases.ListLogEntries
{
    public class ListLogEntriesServiceRequest : IServiceRequest<ListLogEntriesServiceResponse>
    {
        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        public LogEntryLevel Level { get; set; }

        public string Content { get; set; }

        public class Handler : IServiceHandler<ListLogEntriesServiceRequest, ListLogEntriesServiceResponse>
        {
            private readonly ILoggingContext _context;
            private readonly IMapping _mapper;

            public Handler(ILoggingContext context, IMapping mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ListLogEntriesServiceResponse> Handle(ListLogEntriesServiceRequest request)
            {
                var items = _context.LogEntries.AsQueryable();

                if (request.From.HasValue)
                {
                    items = items.Where(item => item.CreatedAt >= request.From);
                }

                if (request.To.HasValue)
                {
                    items = items.Where(item => item.CreatedAt <= request.To);
                }

                if (request.Level != null)
                {
                    items = items.Where(item => item.Level == request.Level);
                }

                if (!string.IsNullOrEmpty(request.Content))
                {
                    items = items.Where(item =>
                        item.Text.IndexOf(request.Content) >= 0 ||
                        item.Title.IndexOf(request.Content) >= 0);
                }

                var result = await items.ToListAsync();

                var projection = _mapper.Map<List<ListLogEntriesServiceResponse.Item>>(result);

                return new ListLogEntriesServiceResponse
                {
                    Items = projection
                };
            }
        }
    }
}