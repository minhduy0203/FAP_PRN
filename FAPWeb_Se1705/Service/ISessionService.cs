using FAPWeb_Se1705.Models;

namespace FAPWeb_Se1705.Service
{
    public interface ISessionService
    {
        public void AddSessions(List<Session> sessions);
        public List<Session> GetSessions();
        public List<Session> GetSessionsByDay(char day);
        public void AddSession(Session session);
    }
}
