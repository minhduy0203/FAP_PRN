using FAPWeb_Se1705.Hubs;
using FAPWeb_Se1705.Logics;
using FAPWeb_Se1705.Models;
using FAPWeb_Se1705.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;

namespace FAPWeb_Se1705.Pages.TimeTable
{
    public class AddModel : PageModel
    {

        private IRoomService roomService;
        private ICourseService courseService;
        private IGroupService groupService;
        private IInstructorService instructorService;
        private ISessionService sessionService;
        private IHubContext<SessionHub> hub;
        public AddModel(IRoomService roomService, ICourseService courseService, IGroupService groupService, IInstructorService instructorService, ISessionService sessionService, IHubContext<SessionHub> hub)
        {
            this.roomService = roomService;
            this.courseService = courseService;
            this.groupService = groupService;
            this.instructorService = instructorService;
            this.sessionService = sessionService;
            this.hub = hub;
        }

        public List<Room> Rooms { get; set; }
        public List<Course> Courses { get; set; }
        public List<Group> Groups { get; set; }
        public List<Instructor> Instructors { get; set; }

        public Session SessionAdd { get; set; }
        public string Message { get; set; }



        public void OnGet()
        {
            GetData();
        }

        public async Task OnPost(Models.Session session)
        {
            List<Models.Session> sessions = sessionService.GetSessions();
            try
            {
                if (TimeTableLogic.ValidateSession(sessions, session))
                {
                    sessionService.AddSession(session);
                    Message = "Add session successfully";
                    await hub.Clients.Clients(UserList.Users.Select(u => u.ConnectionId).ToList()).SendAsync("SessionAdd");
                    //await hub.Clients.Group("ViewSession").SendAsync("CartAdd");
                }

            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            SessionAdd = session;
            GetData();
        }

        public void GetData()
        {
            Rooms = roomService.GetRooms();
            Courses = courseService.GetCourses();
            Groups = groupService.GetGroups();
            Instructors = instructorService.GetInstructors();

        }
    }
}
