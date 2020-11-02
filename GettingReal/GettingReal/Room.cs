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
        List<Room> rooms;

        public Room(string number, double estimatedVolume, double area)
        {
            Number = number;
            EstimatedAirVolume = estimatedVolume;
            Area = Area;
            rooms = new List<Room>();
        }
    }
}
