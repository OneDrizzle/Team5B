using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    public class Room
    {
        public string Number { get; set; }
        public double EstimatedAirVolume { get; set; }
        public double Area { get; set; }
        public double MeasuredAirVolume { get; set; }
        public string Technician { get; set; }

        public Room(string number, double estimatedVolume, double area)
        {
            Number = number;
            EstimatedAirVolume = estimatedVolume;
            Area = Area;
        }

        public double CalculateDeviation()
        {
            return MeasuredAirVolume/EstimatedAirVolume *100;
        }
    }
}
