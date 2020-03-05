namespace POC.Identity.Web.Service
{
    public interface IRedirectUrlComposer
    {
        string ComposeUrl(string user);
    }
}
