using System.ServiceModel;

namespace POC.Channel
{
    public class ChannelManager : IChannelManager
    {
        private static IChannelManager _instance;
        public static IChannelManager Instance => _instance ?? (_instance = new ChannelManager());

        private ChannelManager() { }

        public TChannel GetChannel<TChannel>(IAddress channelAddress)
        {
            var address = new EndpointAddress(channelAddress.Url);
            var binding = new BasicHttpBinding();
            var channel = new ChannelFactory<TChannel>(binding, address);
            var service = channel.CreateChannel();

            return service;
        }
    }
}
