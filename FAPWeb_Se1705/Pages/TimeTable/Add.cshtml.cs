using FAPWeb_Se1705.Logics;
using FAPWeb_Se1705.Models;
using FAPWeb_Se1705.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FAPWeb_Se1705.Pages.TimeTable
{
    public class AddModel : PageModel
    {

        private IRoomService roomService;
        private ICourseService courseService;
        private IGroupService groupService;
        private IInstructorService instructorService;
        private ISessionService sessionService;
        public AddModel(IRoomService roomService, ICourseService courseService, IGroupService groupService, IInstructorService instructorService, ISessionService sessionService)
        {
            this.roomService = roomService;
            this.courseService = courseService;
            this.groupService = groupService;
            this.instructorService = instructorService;
            this.sessionService = sessionService;
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

        public void OnPost(Models.Session session)
        {
            List<Models.Session> sessions = sessionService.GetSessions();
            try
            {
                if (TimeTableLogic.ValidateSession(sessions, session))
                {
                    sessionService.AddSession(session);
                    Message = "Add session successfully";
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
