using POC.Channel;
using POC.Identity.Web.Common;

namespace POC.Identity.Web.Service
{
    public class RedirectUrlComposer : IRedirectUrlComposer
    {
        public string ComposeUrl(string user)
        {
            var address = new EnviromentLocatedAddress(IdentityDefaults.IdentityRedirectUrl);
            var baseUrl = address.Url;

            if (!baseUrl.EndsWith("/"))
            {
                baseUrl += "/";
            }

            return $"{baseUrl}?user={user}";
        }
    }
}