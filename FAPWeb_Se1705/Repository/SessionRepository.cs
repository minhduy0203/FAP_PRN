using FAPWeb_Se1705.Models;
using Microsoft.EntityFrameworkCore;

namespace FAPWeb_Se1705.Repository
{
    public class SessionRepository : ISessionRepostiory
    {
        private FAPPRJContext context;

        public SessionRepository(FAPPRJContext context)
        {
            this.context = context;
        }

        public void AddSession(Session session)
        {
            context.Sessions.Add(session);
            context.SaveChanges();
        }

        public void AddSessions(List<Session> sessions)
        {
            context.Sessions.AddRange(sessions);
            context.SaveChanges();
        }

        public List<Session> GetSessions()
        {
            return context.Sessions.ToList();
        }

        public List<Session> GetSessions(char day)
        {
            return context.Sessions.Where((s) => (String.IsNullOrEmpty(day.ToString()) && s.TimeSlot.Contains("2")) || s.TimeSlot.Contains(day.ToString())).ToList();
        }

        public Session GetSession(int id)
        {
            return context.Sessions
                .Include(s => s.CourseCodeNavigation)
                .Include(s => s.InstructorCodeNavigation)
                .FirstOrDefault(s => s.Id == id);
        }

        public void RemoveSession(int id)
        {
            Session session = context.Sessions.FirstOrDefault(s => s.Id == id);
            if (session != null)
            {
                context.Sessions.Remove(session);
                context.SaveChanges();  
            }
        }
    }
}
