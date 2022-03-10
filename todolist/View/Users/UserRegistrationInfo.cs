using System.Runtime.Serialization;

namespace View.Users
{
    [DataContract]
    public class UserRegistrationInfo
    {
        [DataMember(IsRequired = true)]
        public string Login { get; set; }

        [DataMember(IsRequired = true)]
        public string Password { get; set; }
    }
}
