using System;
using System.Collections.Generic;

namespace FAPWeb_Se1705.Models
{
    public partial class Course
    {
        public Course()
        {
            Sessions = new HashSet<Session>();
        }

        public string CourseName { get; set; } = null!;
        public string CourseCode { get; set; } = null!;

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
