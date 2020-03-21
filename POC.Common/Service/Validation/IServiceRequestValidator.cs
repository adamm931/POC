using System.Threading.Tasks;

namespace POC.Common.Service.Validation
{
    public interface IServiceRequestValidator
    {
        Task ValidateAsync<TRequest>(TRequest request);
    }
}
