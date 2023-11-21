using Microsoft.AspNetCore.SignalR;
using SignalR_Common;

namespace SignalR_Server.Hubs
{
    public class NotificationHub : Hub
    {
        public Task SenaMessage(Message message) {
            return Clients.Others.SendAsync("Send", message);
        }
    }
}
