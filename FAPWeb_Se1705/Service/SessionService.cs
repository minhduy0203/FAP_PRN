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

        public void AddSessions(List<Session> sessions)
        {
            repostiory.AddSessions(sessions);
        }

        public void GetSessions()
        {
            repostiory.GetSessions();
        }
    }
}
