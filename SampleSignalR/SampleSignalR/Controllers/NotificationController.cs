using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR_Common;
using SignalR_Server.Hubs;
using SignalR_Server.Hubs.Interfaces;

namespace SignalR_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<NotificationHub, INotificationClient> hubContext;
        public NotificationController(IHubContext<NotificationHub, INotificationClient> hubContext)
        {
            this.hubContext = hubContext;
        }
        [HttpPost]
        public async Task<IActionResult> PushNotification([FromBody]Message message) {
            await hubContext.Clients.All.Send(message);
            return Ok();
        }
    }
}
