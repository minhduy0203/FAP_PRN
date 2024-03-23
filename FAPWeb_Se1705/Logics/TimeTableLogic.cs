using FAPWeb_Se1705.Models;
using Microsoft.VisualBasic.FileIO;

namespace FAPWeb_Se1705.Logics
{
    public class TimeTableLogic
    {

        public static List<Session> GetValidSessions(Stream stream)
        {
            List<Session> result = new List<Session>();
            using (TextFieldParser csvParser = new TextFieldParser(stream))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                csvParser.ReadLine();

                while (!csvParser.EndOfData)
                {
                    string[] fields = csvParser.ReadFields();
                    string GroupName = fields[0];
                    string InstructorCode = fields[1];
                    string CourseCode = fields[2];
                    string Timeslot = fields[3];
                    string Room = fields[4];
                    Session Session = new Session();

                    Session.GroupName = GroupName;
                    Session.InstructorCode = InstructorCode;
                    Session.TimeSlot = Timeslot;
                    Session.CourseCode = CourseCode;
                    Session.RoomName = Room;
                    if (ValidateSession(result, Session))
                    {
                        result.Add(Session);
                    }

                }
            }
            return result;
        }

        public static bool ValidateSession(List<Session> result, Session sessionCheck)
        {

            foreach (Session s in result)
            {
                if (ValidateTimeSlot(sessionCheck.TimeSlot, s.TimeSlot) && ValidateGroup(sessionCheck.GroupName, s.RoomName))
                {
                    return false;
                }

                if (ValidateTimeSlot(sessionCheck.TimeSlot, s.TimeSlot) && ValidateTeacher(sessionCheck.InstructorCode, s.InstructorCode))
                {
                    return false;

                }

                if (ValidateTimeSlot(sessionCheck.TimeSlot, s.TimeSlot) && ValidateRoom(sessionCheck.RoomName, s.RoomName))
                {
                    return false;
                }

                if (ValidateRoom(sessionCheck.RoomName, s.RoomName) && ValidateSubject(sessionCheck.CourseCode, s.CourseCode))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ValidateGroup(string groupA, string groupB)
        {
            groupA = groupA.Trim();
            groupB = groupB.Trim();
            return groupA.Equals(groupB);
        }

        public static bool ValidateTeacher(string teacherA, string teacherB)
        {
            teacherA = teacherA.Trim();
            teacherB = teacherB.Trim();
            return teacherA.Equals(teacherB);
        }

        public static bool ValidateSubject(string subA, string subB)
        {
            subA = subA.Trim();
            subB = subB.Trim();
            return subA.Equals(subB);
        }

        public static bool ValidateRoom(string roomA, string roomB)
        {
            roomA = roomA.Trim();
            roomB = roomB.Trim();
            return roomA.Equals(roomB);
        }

        public static bool ValidateTimeSlot(string timeA, string timeB)
        {
            bool result = false;
           
            timeA = timeA.Trim();
            timeB = timeB.Trim();

            if (timeA.Length != 3 || timeB.Length != 3)
            {
                throw new Exception("Input is not valid");
            }

            if (timeA[0] == timeB[0])
            {
                if (timeA[1] == timeB[1] || timeA[2] == timeB[2])
                {
                    result = true;
                }

            }
            return result;
        }
    }
}
