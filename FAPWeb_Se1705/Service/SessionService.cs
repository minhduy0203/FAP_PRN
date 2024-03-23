using FAPWeb_Se1705.Models;
using FAPWeb_Se1705.Repository;

namespace FAPWeb_Se1705.Service
{
    public class SessionService : ISessionService
    {
        private ISessionRepostiory repostiory;

        public SessionService(ISessionRepostiory repostiory)
        {
            this.repostiory = repostiory;
        }

        public void AddSession(Session session)
        {
            repostiory.AddSession(session);
        }

        public void AddSessions(List<Session> sessions)
        {
            repostiory.AddSessions(sessions);
        }

        public List<Session> GetSessions()
        {
            return repostiory.GetSessions();
        }

        public List<Session> GetSessionsByDay(char day)
        {
            return repostiory.GetSessions(day);
        }


    }
}
