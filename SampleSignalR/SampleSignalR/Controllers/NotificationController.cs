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

        [HttpPost]
        public async Task<IActionResult> PushNotification([FromBody]Message message, [FromServices]IHubContext<NotificationHub, INotificationClient> hubContext) {
            await hubContext.Clients.All.Send(message);
            return Ok();
        }
    }
}
