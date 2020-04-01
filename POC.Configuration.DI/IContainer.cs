using System;
using System.Collections.Generic;

namespace POC.Configuration.DI
{
    public interface IContainer
    {
        void Register<TFrom, TTo>() where TTo : TFrom;

        void RegisterSingleton<TFrom, TTo>() where TTo : TFrom;

        void Register(Type type);

        void RegisterInstance<TInstance>(TInstance instance);

        TType Resolve<TType>();

        object Resolve(Type type);

        IEnumerable<object> ResolveAll(Type type);

        bool IsRegistered(Type type);

        object RegisterThanResolve(Type type);

        TType RegisterThanResolve<TType>();
    }
}
