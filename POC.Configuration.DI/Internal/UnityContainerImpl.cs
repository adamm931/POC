using System;
using Unity;

namespace POC.Configuration.DI.Internal
{
    internal class UnityContainerImpl : IContainer
    {
        private readonly IUnityContainer _container;

        public UnityContainerImpl(IUnityContainer container)
        {
            _container = container;
        }

        public bool IsRegistered(Type type)
        {
            return _container.IsRegistered(type);
        }

        public void Register<TFrom, TTo>() where TTo : TFrom
        {
            _container.RegisterType<TFrom, TTo>();
        }

        public void Register(Type type)
        {
            _container.RegisterType(type);
        }

        public void RegisterInstance<TInstance>(TInstance instance)
        {
            _container.RegisterInstance(instance);
        }

        public TType Resolve<TType>()
        {
            return _container.Resolve<TType>();
        }

        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }
    }
}
