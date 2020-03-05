using System;
using System.Runtime.Serialization;

namespace POC.Identity.Service.Models
{
    [DataContract]
    public class ServiceResponse<TResponse>
    {
        [DataMember]
        public bool IsSuccess { get; set; }

        [DataMember]
        public string FailReason { get; set; }

        [DataMember]
        public TResponse Response { get; set; }

        public static ServiceResponse<TResponse> Success(TResponse response)
        {
            return new ServiceResponse<TResponse>(response);
        }

        public static ServiceResponse<TResponse> Fail(string failResponse)
        {
            return new ServiceResponse<TResponse>(failResponse);
        }

        public static ServiceResponse<TResponse> Fail(Exception exception)
        {
            return new ServiceResponse<TResponse>(exception.Message);
        }

        private ServiceResponse(TResponse response)
        {
            Response = response;
            IsSuccess = true;
        }

        private ServiceResponse(string failReason)
        {
            FailReason = failReason;
            IsSuccess = false;
        }
    }
}