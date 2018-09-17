using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BattleRoyaleSolutions.Web.Hubs
{
    public class ApplicationHub : Hub
    {
        public static List<UserHub> userHub = new List<UserHub>();

        public void SendCommand()
        {
            Clients.All.SendAsync("displayTime", $"Server Date: {DateTime.UtcNow:T}");
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public Task ReceiveMessage(string message)
        {
            return Clients.Client(Context.ConnectionId).SendAsync("ReceiveMessage", message);
        }

        public Task SendMessage(string message)
        {
            return Clients.Client(Context.ConnectionId).SendAsync("SendCommand", $"Server Date: {DateTime.UtcNow:T}");
        }
    }

    public class UserHub
    {

        public string Name { get; set; }
        public string ConnectionIds { get; set; }
    }
}
