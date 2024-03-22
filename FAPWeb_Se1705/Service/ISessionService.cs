using FAPWeb_Se1705.Models;

namespace FAPWeb_Se1705.Service
{
    public interface ISessionService
    {
        public void AddSessions(List<Session> sessions);
        public void GetSessions();
    }
}
