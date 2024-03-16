using System;
using System.Collections.Generic;

namespace FAPWeb_Se1705.Models
{
    public partial class Group
    {
        public Group()
        {
            Sessions = new HashSet<Session>();
        }

        public string GroupName { get; set; } = null!;
        public int CourseId { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
