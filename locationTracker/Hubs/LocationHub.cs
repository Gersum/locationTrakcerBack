using System;
using Microsoft.AspNetCore.SignalR;

namespace locationTracker.Hubs
{
    public class LocationHub : Hub
    {
        public async Task SendLocation(string vehicleId, double lat, double lng)
        {
            await Clients.All.SendAsync("ReceiveVehicleLocation", vehicleId, lat, lng);
        }
    }
}

