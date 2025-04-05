using System;
namespace locationTracker.Models
{
    // Models/Location.cs
    public class Location
    {
        public string DeviceId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Timestamp { get; set; }
    }

}