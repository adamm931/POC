using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace POC.Configuration.DI.Mvc
{
    public class PocDependancyResolver<TType> : IDependencyResolver
    {
        private readonly IContainer _container;

        private PocDependancyResolver(IContainer container)
        {
            _container = container;
        }

        public PocDependancyResolver() : this(Container<TType>.Instance)
        {
            _container.RegisterInstance<IControllerFactory>(new ContainerControllerFactory(_container));
        }

        public object GetService(Type serviceType)
        {
            return _container.IsRegistered(serviceType) ? _container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.ResolveAll(serviceType);
        }
    }
}
