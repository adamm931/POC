using System;
using System.Threading.Tasks;

namespace POC.Common.Service
{
    public class ServiceRequest
    {
        public async static Task<ServiceResponse<TResponse>> Invoke<TResponse>(Func<Task<TResponse>> request)
            where TResponse : class
        {
            try
            {
                var response = await request();

                return ServiceResponse<TResponse>.Success(response);
            }

            catch (Exception exception)
            {
                return ServiceResponse<TResponse>.Fail(exception);
            }
        }

        public async static Task<ServiceResponse> Invoke(Func<Task> request)
        {
            try
            {
                await request();

                return ServiceResponse.Success();
            }

            catch (Exception exception)
            {
                return ServiceResponse.Fail(exception);
            }
        }
    }
}
