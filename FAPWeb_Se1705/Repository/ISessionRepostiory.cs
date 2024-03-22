using FAPWeb_Se1705.Models;

namespace FAPWeb_Se1705.Repository
{
    public interface ISessionRepostiory
    {
        public void AddSessions(List<Session> sessions);

        public List<Session> GetSessions();
    }
}
