using System;
using System.Collections.Generic;

#nullable disable

namespace StudyBuddyAPI.Models
{
    public partial class Task
    {
        public int UniqueId { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; }
        public bool? Completed { get; set; }

        public virtual Module Module { get; set; }
    }
}
