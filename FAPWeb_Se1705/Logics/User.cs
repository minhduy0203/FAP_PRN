namespace FAPWeb_Se1705.Logics
{
    public class User
    {
        public string ConnectionId { get; set; }
        public User(string connectionId)
        {
            ConnectionId = connectionId;
        }
    }

    public class UserList
    {
        public static List<User> Users { get; set; } = new List<User>();
        public static void AddUser(User user)
        {
            Users.Add(user);
        }

        public static User GetUser(string connectionId)
        {
            return Users.FirstOrDefault(u => u.ConnectionId == connectionId);
        }
    }
}

