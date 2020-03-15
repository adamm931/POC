using POC.Common.Service.Exceptions;
using System;
using System.Runtime.Serialization;

namespace POC.Common.Service
{
    [DataContract]
    public class ServiceResponse<TResponse> : ServiceResponse
    {
        [DataMember]
        public TResponse Response { get; set; }

        public static new ServiceResponse<TResponse> Fail(string failResponse)
        {
            return new ServiceResponse<TResponse>(failResponse);
        }

        public static new ServiceResponse<TResponse> Fail(Exception exception)
        {
            return new ServiceResponse<TResponse>(exception.Message);
        }

        public static ServiceResponse<TResponse> Success(TResponse response)
        {
            return new ServiceResponse<TResponse>
            {
                Response = response,
                IsSuccess = true
            };
        }

        public new TResponse EnsureSuccessfull()
        {
            base.EnsureSuccessfull();

            return Response;
        }

        protected ServiceResponse(string failReason)
        {
            FailReason = failReason;
            IsSuccess = false;
        }

        protected ServiceResponse()
        {
        }
    }

    [DataContract]
    public class ServiceResponse
    {
        [DataMember]
        public bool IsSuccess { get; set; }

        [DataMember]
        public string FailReason { get; set; }

        public static ServiceResponse Success()
        {
            return new ServiceResponse
            {
                IsSuccess = true
            };
        }

        public static ServiceResponse Fail(string failResponse)
        {
            return new ServiceResponse(failResponse);
        }

        public static ServiceResponse Fail(Exception exception)
        {
            return new ServiceResponse(exception.Message);
        }

        public void EnsureSuccessfull()
        {
            if (!IsSuccess)
            {
                throw new ServiceResponseException(this);
            }
        }

        protected ServiceResponse()
        {
        }

        protected ServiceResponse(string failReason)
        {
            FailReason = failReason;
            IsSuccess = false;
        }
    }
}