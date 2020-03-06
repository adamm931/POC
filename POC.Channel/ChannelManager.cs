using POC.Common;
using POC.Identity.Service.Contracts;
using POC.Service.Contracts;
using System.ServiceModel;

namespace POC.Channel
{
    public class ChannelManager : IChannelManager
    {
        private static IChannelManager _instance;
        public static IChannelManager Instance => _instance ?? (_instance = new ChannelManager());

        private ChannelManager() { }

        public TChannel GetChannel<TChannel>(string enviromentVaribaleForChannel)
        {
            var url = EnviromentVariablesFetcher.GetVaraiable(enviromentVaribaleForChannel);

            var address = new EndpointAddress(url);
            var binding = new BasicHttpBinding();
            var channel = new ChannelFactory<TChannel>(binding, address);
            var service = channel.CreateChannel();

            return service;
        }

        public ITodoService GetTodoService()
        {
            return GetChannel<ITodoService>(EnviromentVariables.TodoServiceUrl);
        }

        public IIdentityService GetIdentityService()
        {
            return GetChannel<IIdentityService>(EnviromentVariables.IdentityServiceUrl);
        }
    }
}
