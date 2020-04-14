using System;
using System.Collections.Generic;
using System.Text;

namespace SalesApp.Models
{
    public class CurrentLocation
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string Display
        {
            get
            {
                if (String.IsNullOrEmpty(City))
                {
                    return State;
                }
                else
                {
                    return City + ", " + State;
                }
            }
        }
    }
}
