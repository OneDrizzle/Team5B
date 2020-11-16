using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    [Serializable]
    public class Room
    {
        public string Number { get; set; }
        public double EstimatedAirVolume { get; set; }
        public double Area { get; set; }
        public double Deviation { get; private set; }

        private double measuredAirVolume;

        public double MeasuredAirVolume
        {
            get { return measuredAirVolume; }
            set { measuredAirVolume = value; CalculateDeviation(); }
        }


        public void CalculateDeviation()
        {
            Deviation = MeasuredAirVolume / EstimatedAirVolume; // ****** rigtigt regnestykke ??? ******
        }


        public Room(string number, double estimatedVolume, double area)
        {
            Number = number;
            EstimatedAirVolume = estimatedVolume;
            Area = Area;
        }

        public Room() : this("0",0,0)
        {
        }

    }
}
