using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Unity.Wcf;

namespace POC.Logging.Service.DependancyInjection
{
    public class LoggingServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new UnityServiceHost(LoggingContainer.Instance, serviceType, baseAddresses);
        }
    }
}