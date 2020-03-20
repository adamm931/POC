namespace POC.Common.Mapper
{
    public interface IMapping
    {
        TDestination Map<TDestination>(object source);

        TDestination Map<TDestination>(params object[] sources);
    }
}
