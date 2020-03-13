using POC.Common.Enviroment;
using POC.Identity.Web.Authentication.Service;

namespace POC.Identity.Web.Authentication.Implementation
{
    internal class RedirectUrlProvider : IRedirectUrlProvider
    {
        private string _redireectUrl;

        public string RedirectUrl => _redireectUrl ?? (_redireectUrl = GetUrl());

        public string GetUrl()
        {
            var redirectUrl = EnviromentVariablesFetcher.GetVaraiable(EnviromentVariables.IdentityRedirectUrl);

            if (!redirectUrl.EndsWith("/"))
            {
                redirectUrl += "/";
            }

            return redirectUrl;
        }
    }
}