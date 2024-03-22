using FAPWeb_Se1705.Models;
using FAPWeb_Se1705.Repository;

namespace FAPWeb_Se1705.Service
{
    public class RoomService : IRoomService
    {

        private IRoomRepository roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        public List<Room> GetRooms()
        {
            return roomRepository.GetRooms();
        }
    }
}
