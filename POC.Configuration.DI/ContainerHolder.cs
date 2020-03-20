namespace POC.Configuration.DI
{
    public static class ContainerHolder<TType>
    {
        private static IContainer _container = null;

        public static IContainer Container => _container = _container ?? LoadContainer();

        private static IContainer LoadContainer()
        {
            return ContainerFactory.GetContainer(typeof(TType).Assembly);
        }
    }
}
