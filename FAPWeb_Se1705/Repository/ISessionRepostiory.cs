using FAPWeb_Se1705.Models;

namespace FAPWeb_Se1705.Repository
{
    public interface ISessionRepostiory
    {
        public void AddSessions(List<Session> sessions);

        public List<Session> GetSessions();

        public List<Session> GetSessions(char day);

        public void AddSession(Session session);

        public Session GetSession(int id);

        public void RemoveSession(int id);  
    }
}
