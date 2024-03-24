using FAPWeb_Se1705.Logics;
using Microsoft.AspNetCore.SignalR;

namespace FAPWeb_Se1705.Hubs
{
    public class SessionHub : Hub
    {

        public void SetUser()
        {
            UserList.AddUser(new User(connectionId: Context.ConnectionId));
            //Groups.AddToGroupAsync(Context.ConnectionId,"ViewSession");

        }
    }
}
