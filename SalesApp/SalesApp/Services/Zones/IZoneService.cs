using System;
using System.Collections.Generic;
using System.Text;
using SalesApp.Models;

namespace SalesApp.Services.Zones
{
    public interface IZoneService
    {
        IEnumerable<Zone> GetZones();
        Coordinates GetAssignedLatitudeLongitude();
    }
}
