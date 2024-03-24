using FAPWeb_Se1705.Logics;
using FAPWeb_Se1705.Models;
using FAPWeb_Se1705.Repository;
using System.Text;

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

        public String AddSessions(List<Session> sessions)
        {
            List<Session> SessionDB = GetSessions();
            var csv = new StringBuilder();

            var header = string.Format("{0},{1},{2},{3},{4},{5}", "GroupName", "InstructorCode", "CourseCode", "Timeslot", "Room", "Message");
            csv.AppendLine(header);
            String sessionTemp;
            foreach (Session SessionAdd in sessions)
            {
                try
                {
                    if (TimeTableLogic.ValidateSession(SessionDB, SessionAdd))
                    {
                        AddSession(SessionAdd);
                        SessionDB.Add(SessionAdd);
                        sessionTemp = TimeTableLogic.GetSessionCSV(SessionAdd, "Add successfuly");
                        csv.AppendLine(sessionTemp);
                    }
                }
                catch (Exception ex)
                {
                    sessionTemp = TimeTableLogic.GetSessionCSV(SessionAdd, ex.Message);
                    csv.AppendLine(sessionTemp);
                    continue;
                }
            }

            return csv.ToString();

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
