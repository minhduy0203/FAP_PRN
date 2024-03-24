using FAPWeb_Se1705.Models;
using Microsoft.VisualBasic.FileIO;
using System.Text;

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
                    result.Add(Session);
                    //try
                    //{
                    //    if (ValidateSession(result, Session))
                    //    {
                    //        result.Add(Session);
                    //    }

                    //}
                    //catch (Exception)
                    //{

                    //    continue;
                    //}


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
                    throw new Exception("Time slot and group is duplicated");
                    //return false;
                }

                if (ValidateTimeSlot(sessionCheck.TimeSlot, s.TimeSlot) && ValidateTeacher(sessionCheck.InstructorCode, s.InstructorCode))
                {
                    throw new Exception("Time slot and teacher is duplicated");
                    //return false;

                }

                if (ValidateTimeSlot(sessionCheck.TimeSlot, s.TimeSlot) && ValidateRoom(sessionCheck.RoomName, s.RoomName))
                {
                    throw new Exception("Time slot and room is duplicated");
                    //return false;
                }

                if (ValidateRoom(sessionCheck.RoomName, s.RoomName) && ValidateSubject(sessionCheck.CourseCode, s.CourseCode))
                {
                    throw new Exception("Room and subject is duplicated ");
                    //return false;
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

        //timeA from input , time B from db
        public static bool ValidateTimeSlot(string timeA, string timeB)
        {
            bool result = false;

            timeA = timeA.Trim();
            timeB = timeB.Trim();

            if (timeA.Length != 3 || timeB.Length != 3)
            {
                throw new Exception("Timeslot must contain 3 character");
            }

            if (timeA[0] != 'A' && timeA[0] != 'P')
            {
                throw new Exception("Time slot should start with A or P");
            }

            if (timeA.Length == 3)
            {
                for (int i = 1; i <= 2; i++)
                {
                    if (!timeA[i].ToString().All(char.IsDigit))
                    {
                        throw new Exception("Time slot must contain digit");
                    }
                    else
                    {
                        int number = Int32.Parse(timeA[i].ToString());
                        if (number < 2 || number > 8)
                        {
                            throw new Exception("Digit must range from 2 to 8");
                        }
                    }
                }
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

        public static String GetSessionCSV(Session session, string message)
        {
            var csv = new StringBuilder();
            if (session != null)
            {
                string GroupName = session.GroupName;
                string InstructorCode = session.InstructorCode;
                string CourseCode = session.CourseCode;
                string Timeslot = session.TimeSlot;
                string Room = session.RoomName;
                var newLine = string.Format("{0},{1},{2},{3},{4},{5}", GroupName, InstructorCode, CourseCode, Timeslot, Room, message);
                csv.Append(newLine);

            }
            return csv.ToString();
        }
    }
}
