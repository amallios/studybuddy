using System;
using System.Collections.Generic;

#nullable disable

namespace StudyBuddyAPI.Models
{
    public partial class UsersModule
    {
        public int UniqueId { get; set; }
        public int UserId { get; set; }
        public int ModuleId { get; set; }

        public virtual Module Module { get; set; }
        public virtual User User { get; set; }
    }
}
