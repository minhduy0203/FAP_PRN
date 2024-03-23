using FAPWeb_Se1705.Models;

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
    }
}
