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

        public void AddSessions(List<Session> sessions)
        {
            context.Sessions.AddRange(sessions);
            context.SaveChanges();
        }

        public List<Session> GetSessions()
        {
            return context.Sessions.ToList();
        }
    }
}
