using Microsoft.AspNetCore.SignalR;
using SignalR_Common;
using SignalR_Server.Hubs.Interfaces;
using System.Diagnostics;

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

        public override Task OnConnectedAsync()
        {
            var message = new Message()
            {
                Title = $"New Client connected {Context.ConnectionId}.",
                Body = string.Empty
            };

            Clients.Others.Send(message);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var message = new Message()
            {
                Title = $"Client disconnected {Context.ConnectionId}.",
                Body = string.Empty
            };

            Clients.Others.Send(message);
            return base.OnDisconnectedAsync(exception);
        }

        protected override void Dispose(bool disposing)
        {
            Debug.WriteLine("Hub disposing");
            base.Dispose(disposing);
        }
    }
}
