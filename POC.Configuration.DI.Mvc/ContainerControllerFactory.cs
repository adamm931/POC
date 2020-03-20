using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace POC.Configuration.DI.Mvc
{
    public class ContainerControllerFactory : DefaultControllerFactory
    {
        private readonly IContainer _container;

        public ContainerControllerFactory(IContainer container)
        {
            _container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (!_container.IsRegistered(controllerType))
            {
                _container.Register(controllerType);
            }

            return _container.Resolve(controllerType) as Controller;
        }
    }
}
