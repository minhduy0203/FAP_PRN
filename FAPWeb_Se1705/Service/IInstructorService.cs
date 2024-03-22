using FAPWeb_Se1705.Models;
using FAPWeb_Se1705.Repository;

namespace FAPWeb_Se1705.Service
{
    public interface IInstructorService 
    {
        public List<Instructor> GetInstructors();

    }
}
