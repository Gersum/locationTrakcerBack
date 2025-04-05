using System;
using locationTracker.Hubs;
using locationTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace locationTracker.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly IHubContext<LocationHub> _hubContext;

        public LocationController(IHubContext<LocationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> PostLocation([FromBody] Location location)
        {
            // Save to database (implementation omitted)
            await _hubContext.Clients.All.SendAsync("ReceiveLocation",
                location.DeviceId,
                location.Latitude,
                location.Longitude);

            return Ok();
        }
    }
}

