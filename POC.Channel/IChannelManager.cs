namespace POC.Channel
{
    public interface IChannelManager
    {
        TService GetChannel<TService>(IAddress address);
    }
}
