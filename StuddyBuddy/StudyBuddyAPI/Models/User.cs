using System;
using System.Collections.Generic;

#nullable disable

namespace StudyBuddyAPI.Models
{
    public partial class User
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
            UsersModules = new HashSet<UsersModule>();
        }

        public int UniqueId { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<UsersModule> UsersModules { get; set; }
    }
}
