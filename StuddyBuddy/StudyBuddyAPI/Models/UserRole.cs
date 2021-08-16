using System;
using System.Collections.Generic;

#nullable disable

namespace StudyBuddyAPI.Models
{
    public partial class UserRole
    {
        public int UniqueId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
