using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebConferenceApp.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await this.Clients.All.SendAsync("SendAction", Context.User.Identity.Name, "Joined");
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await this.Clients.All.SendAsync("SendAction", Context.User.Identity.Name, "Left");
        }

        public async Task Send(string Message)
        {
            await Clients.All.SendAsync("SendMessage", Context.User.Identity.Name, Message);
        }
    }
}
