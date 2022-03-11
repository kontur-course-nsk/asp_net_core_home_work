using System;
using System.Runtime.Serialization;

namespace View.Users
{
    [DataContract]
    public sealed class UserCreationInfo
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }
    }
}
