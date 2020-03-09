using POC.Web.Authentication.Contracts;
using System;
using System.Web;

namespace POC.Web.Authentication.Implementation
{
    internal class QueryStringUser : IUser
    {
        private const string QueryStringUserParam = "user";

        public QueryStringUser(HttpRequestBase request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Username = request.QueryString[QueryStringUserParam];
        }

        public string Username { get; }
    }
}
