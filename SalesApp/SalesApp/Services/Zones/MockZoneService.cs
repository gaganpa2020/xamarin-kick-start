using System.Collections.Generic;
using SalesApp.Models;

namespace SalesApp.Services.Zones
{
    public class MockZoneService : IZoneService
    {
        public IEnumerable<Zone> GetZones()
        {
            return new List<Zone>
            {
                new Zone
                {
                    Name = "Olive abandoned trailer park",
                    Color = "Red",
                    Type = "Nogo",
                    Bounds = new List<Coordinates>
                    {
                        new Coordinates() {Latitude = 37.403374, Longitude = -94.707560},
                        new Coordinates() {Latitude = 37.402428, Longitude = -94.707581},
                        new Coordinates() {Latitude = 37.402394, Longitude = -94.705639},
                        new Coordinates() {Latitude = 37.403868, Longitude = -94.705703},
                    }
                }
            };
        }

        public Coordinates GetAssignedLatitudeLongitude()
        {
            return new Coordinates
            {
                Latitude = 37.402657,
                Longitude = -94.709469
            };
        }
    }
}