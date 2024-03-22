using FAPWeb_Se1705.Models;

namespace FAPWeb_Se1705.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private FAPPRJContext context;

        public RoomRepository(FAPPRJContext context)
        {
            this.context = context;
        }

        public List<Room> GetRooms()
        {
            return context.Rooms.ToList();
        }
    }
}
