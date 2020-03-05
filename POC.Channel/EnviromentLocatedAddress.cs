using POC.Common;

namespace POC.Channel
{
    public class EnviromentLocatedAddress : IAddress
    {
        public EnviromentLocatedAddress(string enviromentVariable)
        {
            Url = EnviromentVariablesFetcher.GetVaraiable(enviromentVariable);
        }

        public string Url { get; }
    }
}
