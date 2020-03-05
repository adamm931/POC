using System.Runtime.Serialization;

namespace POC.Identity.Service.Models
{
    [DataContract]
    public class UserLoginServiceResponse
    {
        [DataMember]
        public bool IsAuthenticated { get; set; }
    }
}