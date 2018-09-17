using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace BattleRoyaleSolutions.Web.Hubs
{
    public class ApplicationHub : Hub
    {
        public void SendCommand()
        {
            Clients.All.SendAsync("displayTime", $"Server Date: {DateTime.UtcNow:T}");
        }

        public Task ReceiveMessage(string message)
        {
            return Clients.Client(Context.ConnectionId).SendAsync("ReceiveMessage", message);
        }

        public Task SendMessage(string message)
        {
            return Clients.Client(Context.ConnectionId).SendAsync("ReceiveMessage", $"Server Date: {DateTime.UtcNow:T}");
        }
    }
}
