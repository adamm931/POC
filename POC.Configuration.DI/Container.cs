namespace POC.Configuration.DI
{
    public class Container<TType>
    {
        private static IContainer _instance = null;

        public static IContainer Instance => _instance = _instance ?? LoadContainer();

        private static IContainer LoadContainer()
        {
            return ContainerFactory.GetContainer(typeof(TType).Assembly);
        }
    }
}
