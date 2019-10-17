using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfDraft2.Hubs
{
    public class DraftHub : Hub
    {

        private List<string> ConnectedUsers = new List<string>();
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            var id = Context.User.Identity.Name;
            ConnectedUsers.Add(id);
            await Clients.All.SendAsync("ShowUsers", ConnectedUsers);
            await base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var conUser = ConnectedUsers.FirstOrDefault(x => x == Context.ConnectionId);

            if(conUser != null)
            {
                ConnectedUsers.Remove(conUser);
            }
            return base.OnDisconnectedAsync(exception);
        }


        public async Task DraftPlayer(string user, string userID, string playerID)
        {
            await Clients.All.SendAsync("NotifyDraft", user, playerID);
            await Clients.User(userID).SendAsync("AddPlayer", playerID);
            await Clients.All.SendAsync("RemoveDrafted", playerID);
        }
    }
}
