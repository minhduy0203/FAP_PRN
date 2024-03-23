using FAPWeb_Se1705.Logics;
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
            session.TimeSlot = session.TimeSlot.Trim();
            session.RoomName = session.RoomName.Trim();
            session.GroupName = session.GroupName.Trim();
            session.CourseCode = session.CourseCode.Trim();
            session.InstructorCode = session.InstructorCode.Trim();
            repostiory.AddSession(session);
        }

        public void AddSessions(List<Session> sessions)
        {
            List<Session> sessionsDB = repostiory.GetSessions();
            foreach (Session session in sessions)
            {
                session.TimeSlot = session.TimeSlot.Trim();
                session.RoomName = session.RoomName.Trim();
                session.GroupName = session.GroupName.Trim();
                session.CourseCode = session.CourseCode.Trim();
                session.InstructorCode = session.InstructorCode.Trim();
                try
                {
                    if (TimeTableLogic.ValidateSession(sessionsDB, session))
                    {
                        repostiory.AddSession(session);
                    }
                }
                catch (Exception)
                {

                    continue;
                }

            }

        }

        public Session GetSession(int id)
        {
            return repostiory.GetSession(id);
        }

        public List<Session> GetSessions()
        {
            return repostiory.GetSessions();
        }

        public List<Session> GetSessionsByDay(char day)
        {
            return repostiory.GetSessions(day);
        }

        public void RemoveSession(int id)
        {
            repostiory.RemoveSession(id);
        }

        public Session UpdateSession(Session session)
        {
            return repostiory.UpdateSession(session);
        }
    }
}
