using System;

namespace POC.Configuration.DI
{
    public interface IContainer
    {
        void Register<TFrom, TTo>() where TTo : TFrom;

        void Register(Type type);

        void RegisterInstance<TInstance>(TInstance instance);

        TType Resolve<TType>();

        object Resolve(Type type);

        bool IsRegistered(Type type);
    }
}
