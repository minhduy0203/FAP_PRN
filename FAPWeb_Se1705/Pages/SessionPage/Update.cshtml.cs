using FAPWeb_Se1705.Logics;
using FAPWeb_Se1705.Models;
using FAPWeb_Se1705.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FAPWeb_Se1705.Pages.SessionPage
{
    public class UpdateModel : PageModel
    {
        private ISessionService sessionService;

        private IRoomService roomService;
        private ICourseService courseService;
        private IGroupService groupService;
        private IInstructorService instructorService;

        public UpdateModel(ISessionService sessionService, IRoomService roomService, ICourseService courseService, IGroupService groupService, IInstructorService instructorService)
        {
            this.sessionService = sessionService;
            this.roomService = roomService;
            this.courseService = courseService;
            this.groupService = groupService;
            this.instructorService = instructorService;
        }

        [BindProperty(SupportsGet = true)]
        public int id { get; set; }
        public Models.Session Session { get; set; }

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
            try
            {
                List<Models.Session> sessions = sessionService.GetSessions();
                Session UpdateSession = sessions.FirstOrDefault(s => s.Id == session.Id);
                sessions.Remove(UpdateSession);
                if (TimeTableLogic.ValidateSession(sessions, session))
                {
                    sessionService.UpdateSession(session);
                    Message = "Update successfully";

                }
                else
                {
                    throw new Exception("Update failed");
                }

            }
            catch (Exception)
            {
                Message = "Update failed";
            }
            GetData();
        }

        public void GetData()
        {
            Session = sessionService.GetSession(id);
            Rooms = roomService.GetRooms();
            Courses = courseService.GetCourses();
            Groups = groupService.GetGroups();
            Instructors = instructorService.GetInstructors();
        }


    }
}
