using POC.Common;

namespace POC.Identity.Web.Service
{
    public class RedirectUrlComposer : IRedirectUrlComposer
    {
        public string ComposeUrl(string user)
        {
            var baseUrl = EnviromentVariablesFetcher.GetVaraiable(EnviromentVariables.IdentityRedirectUrl);

            if (!baseUrl.EndsWith("/"))
            {
                baseUrl += "/";
            }

            return $"{baseUrl}?user={user}";
        }
    }
}