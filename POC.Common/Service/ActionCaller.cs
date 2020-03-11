using System;
using System.Threading.Tasks;

namespace POC.Common.Service
{
    public class ServiceTrigger
    {
        public async static Task<ServiceResponse<TResponse>> Handle<TResponse>(Func<Task<TResponse>> handle)
            where TResponse : class
        {
            try
            {
                var response = await handle();

                return ServiceResponse<TResponse>.Success(response);
            }

            catch (Exception exception)
            {
                return ServiceResponse<TResponse>.Fail(exception);
            }
        }

        public async static Task<ServiceResponse> Handle(Func<Task> handle)
        {
            try
            {
                await handle();

                return ServiceResponse.Success();
            }

            catch (Exception exception)
            {
                return ServiceResponse.Fail(exception);
            }
        }
    }
}
