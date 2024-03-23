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
        private TimeTableLogic timeTableLogic;
        private ISessionService sessionService;
        public AddModel(IRoomService roomService, ICourseService courseService, IGroupService groupService, IInstructorService instructorService, TimeTableLogic timeTableLogic, ISessionService sessionService)
        {
            this.roomService = roomService;
            this.courseService = courseService;
            this.groupService = groupService;
            this.instructorService = instructorService;
            this.timeTableLogic = timeTableLogic;
            this.sessionService = sessionService;
        }

        public List<Room> Rooms { get; set; }
        public List<Course> Courses { get; set; }
        public List<Group> Groups { get; set; }
        public List<Instructor> Instructors { get; set; }
        public string Message { get; set; }



        public void OnGet()
        {
            GetData();
        }

        public void OnPost(Session session)
        {
            List<Session> sessions = sessionService.GetSessions();
            if (TimeTableLogic.ValidateSession(sessions, session))
            {
                sessionService.AddSession(session);
            }
            else
            {
                Message = "Add error";
            }

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
