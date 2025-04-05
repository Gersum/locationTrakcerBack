using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using locationTracker.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace locationTracker
{
   
public class FleetSimulationService
{
    private readonly IHubContext<LocationHub> _hubContext;

    public FleetSimulationService(IHubContext<LocationHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SimulateFleetMovement()
    {
        var vehicles = new List<(string VehicleId, double Latitude, double Longitude)>
        {
            ("Vehicle1", 8.9806, 38.7578), // Example vehicle 1
            ("Vehicle2", 8.9820, 38.7600), // Example vehicle 2
            ("Vehicle3", 8.9838, 38.7963)  // Example vehicle 3
        };

        while (true)
        {
            foreach (var vehicle in vehicles)
            {
                // Simulate movement by slightly modifying the coordinates
                var newLatitude = vehicle.Latitude + (new Random().NextDouble() - 0.5) * 0.001;
                var newLongitude = vehicle.Longitude + (new Random().NextDouble() - 0.5) * 0.001;

                // Broadcast the updated location
                await _hubContext.Clients.All.SendAsync("ReceiveVehicleLocation", vehicle.VehicleId, newLatitude, newLongitude);

                // Simulate delay
                await Task.Delay(1000);
            }
        }
    }
}}