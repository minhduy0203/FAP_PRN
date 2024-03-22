using FAPWeb_Se1705.Models;

namespace FAPWeb_Se1705.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private FAPPRJContext context;

        public CourseRepository(FAPPRJContext context)
        {
            this.context = context;
        }

        public List<Course> GetCourses()
        {
            return context.Courses.ToList();
        }
    }
}
