using System;
using System.Collections.Generic;

#nullable disable

namespace StudyBuddyAPI.Models
{
    public partial class Module
    {
        public Module()
        {
            Tasks = new HashSet<Task>();
            UsersModules = new HashSet<UsersModule>();
        }

        public int UniqueId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? Completed { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<UsersModule> UsersModules { get; set; }
    }
}
