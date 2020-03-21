using System.Threading.Tasks;

namespace POC.Common.Domain
{
    public interface IUnitOfWork
    {
        Task Save();
    }
}
