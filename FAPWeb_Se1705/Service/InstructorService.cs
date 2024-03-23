using FAPWeb_Se1705.Models;
using FAPWeb_Se1705.Repository;

namespace FAPWeb_Se1705.Service
{
    public class InstructorService : IInstructorService
    {
        private IInstructorRepository instructorRepository;

        public InstructorService(IInstructorRepository instructorRepository)
        {
            this.instructorRepository = instructorRepository;
        }

        public List<Instructor> GetInstructors()
        {
            return instructorRepository.GetInstructors();
        }
    }
}
