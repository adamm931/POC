using System;
using System.ServiceModel;

namespace POC.Service.Client
{
    public class ChannelBuilder<TService>
    {
        private string _url;
        private string _enviromentVaraibleName;

        private bool isUriBase = false;

        public static ChannelBuilder<TService> Create() => new ChannelBuilder<TService>();

        private ChannelBuilder()
        {
        }

        public ChannelBuilder<TService> WithUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(url);
            }

            _url = url;

            isUriBase = true;

            return this;
        }

        public ChannelBuilder<TService> WithUrlFromEnv(string enviromentVaraibleName)
        {
            if (string.IsNullOrEmpty(enviromentVaraibleName))
            {
                throw new ArgumentNullException(enviromentVaraibleName);
            }

            _enviromentVaraibleName = enviromentVaraibleName;

            return this;
        }

        public TService Build()
        {
            var url = GetServiceUrl();

            var address = new EndpointAddress(url);
            var binding = new BasicHttpBinding();
            var channel = new ChannelFactory<TService>(binding, address);
            var service = channel.CreateChannel();

            return service;
        }

        private string GetServiceUrl()
        {
            return isUriBase
                ? _url
                : Environment.GetEnvironmentVariable(_enviromentVaraibleName);
        }
    }
}