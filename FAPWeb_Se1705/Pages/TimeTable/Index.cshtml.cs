using FAPWeb_Se1705.Models;
using FAPWeb_Se1705.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FAPWeb_Se1705.Pages.TimeTable
{
    public class IndexModel : PageModel
    {
        private ISessionService SessionService;
        private IRoomService RoomService;

        public IndexModel(ISessionService sessionService, IRoomService roomService)
        {
            SessionService = sessionService;
            RoomService = roomService;
        }

        public List<Session> Sessions { get; set; }
        public List<Room> Rooms { get; set; }

        [BindProperty(SupportsGet = true)]
        public char day { get; set; } = '2';
        public void OnGet()
        {
            GetData();
        }

        private void GetData()
        {
            Sessions = SessionService.GetSessionsByDay(day);
            Rooms = RoomService.GetRooms();
        }
    }
}
