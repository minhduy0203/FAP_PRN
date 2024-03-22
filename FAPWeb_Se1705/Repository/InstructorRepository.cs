using FAPWeb_Se1705.Models;

namespace FAPWeb_Se1705.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        private FAPPRJContext context;

        public InstructorRepository(FAPPRJContext context)
        {
            this.context = context;
        }

        public List<Instructor> GetInstructors()
        {
            return context.Instructors.ToList();
        }
    }
}
