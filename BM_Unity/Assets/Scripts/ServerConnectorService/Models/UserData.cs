using System;

namespace Server.Models
{
    [Serializable]
    public class UserData
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public UserRoles Role { get; set; }
        public string Phone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
    }
}
