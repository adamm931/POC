using System;

namespace POC.Common.Service.Exceptions
{
    public class ServiceResponseException : Exception
    {
        public ServiceResponseException(string message) : base(message)
        {
        }

        public ServiceResponseException(ServiceResponse seriviceResponse)
            : base($"Service request has failed. {seriviceResponse.FailReason}")
        {
        }
    }
}
