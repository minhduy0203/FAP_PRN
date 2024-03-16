using System;
using System.Collections.Generic;

namespace FAPWeb_Se1705.Models
{
    public partial class Instructor
    {
        public Instructor()
        {
            Sessions = new HashSet<Session>();
        }

        public string InstructorCode { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? Dob { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
