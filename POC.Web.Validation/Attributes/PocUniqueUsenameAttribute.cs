using POC.Channel;
using POC.Identity.Service.UseCases.CheckUsername;
using POC.Web.Validation.Resources;

namespace POC.Web.Validation.Attributes
{
    public class PocUniqueUsenameAttribute : PocUsernameAttribute
    {
        public PocUniqueUsenameAttribute()
        {
            ErrorMessage = ValidationErrors.UniqueUsername;
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
