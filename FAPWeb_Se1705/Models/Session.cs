using System;
using System.Collections.Generic;

namespace FAPWeb_Se1705.Models
{
    public partial class Session
    {
        public int Id { get; set; }
        public string? CourseCode { get; set; }
        public string GroupName { get; set; } = null!;
        public string InstructorCode { get; set; } = null!;
        public string RoomName { get; set; } = null!;
        public string TimeSlot { get; set; } = null!;

        public virtual Course? CourseCodeNavigation { get; set; }
        public virtual Group GroupNameNavigation { get; set; } = null!;
        public virtual Instructor InstructorCodeNavigation { get; set; } = null!;
        public virtual Room RoomNameNavigation { get; set; } = null!;
    }
}
