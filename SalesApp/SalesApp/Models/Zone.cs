using System;
using System.Collections.Generic;
using System.Text;

namespace SalesApp.Models
{
    public class Zone
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }

        public List<Coordinates> Bounds { get; set; }
    }

    public class Coordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
