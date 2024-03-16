using System;
using System.Collections.Generic;

namespace FAPWeb_Se1705.Models
{
    public partial class Room
    {
        public Room()
        {
            Sessions = new HashSet<Session>();
        }

        public string RoomName { get; set; } = null!;

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
