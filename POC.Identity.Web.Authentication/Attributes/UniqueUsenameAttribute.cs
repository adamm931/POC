using POC.Channel;
using POC.Identity.Service.Models;

namespace POC.Identity.Web.Authentication.Attributes
{
    public class UniqueUsenameAttribute : UsernameAttribute
    {
        public UniqueUsenameAttribute()
        {
            ErrorMessage = "Username must be unique";
        }

        public override bool IsValid(object value)
        {
            var isValid = base.IsValid(value);

            if (!isValid)
            {
                return false;
            }

            var identityService = ChannelManager.Instance.GetIdentityService();

            var request = new CheckUsernameServiceRequest
            {
                Username = value.ToString()
            };

            var response = identityService
                .CheckUsernameAsync(request)
                .Result
                .EnsureSuccessfull();

            return response.IsAvailable;
        }
    }
}
