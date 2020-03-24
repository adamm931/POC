using System.Threading.Tasks;

namespace POC.MQ.Contracts
{
    public interface IBusConsumer
    {
        Task ConsumeAsync(string quename);
    }
}
