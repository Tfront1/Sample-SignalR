using Microsoft.AspNetCore.SignalR;
using SignalR_Common;
using SignalR_Server.Hubs.Interfaces;

namespace SignalR_Server.Hubs
{
    public class NotificationHub : Hub<INotificationClient>
    {
        public Task SenaMessage(Message message) {
            if (Context.Items.ContainsKey("user_name")) {
                message.Title = (string)Context.Items["user_name"];
            }

            return Clients.Others.Send(message);
        }

        public Task SetName(string name) {
            Context.Items.TryAdd("user_name", name);
            return Task.CompletedTask;
        }
    }
}
