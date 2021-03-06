﻿using POC.Common.Service;
using POC.Common.Service.Factory;
using POC.Logging.Service.Contracts;
using POC.Logging.Service.Models.Log;
using POC.Logging.Service.UseCases.ListLogEntries;
using System.Threading.Tasks;

namespace POC.Logging.Service
{
    public class LoggingService : ILoggingService
    {
        private readonly IServiceMediator _serviceMediator = ServiceMediatorFactory.CreateMediator();

        public async Task<ServiceResponse> AddLogEntryAsync(AddLogEntryServiceRequest request)
        {
            return await _serviceMediator.Handle(request);
        }

        public async Task<ServiceResponse<ListLogEntriesServiceResponse>> QueryLogEntriesAsync(ListLogEntriesServiceRequest request)
        {
            return await _serviceMediator.Handle<ListLogEntriesServiceRequest, ListLogEntriesServiceResponse>(request);
        }
    }
}
