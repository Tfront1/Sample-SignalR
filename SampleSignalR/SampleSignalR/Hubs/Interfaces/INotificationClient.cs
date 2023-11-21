using SignalR_Common;

namespace SignalR_Server.Hubs.Interfaces
{
    public interface INotificationClient
    {
        Task Send(Message message);
    }
}
