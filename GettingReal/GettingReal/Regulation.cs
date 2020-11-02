using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    public class Regulation
    {
        public double ActualAirVolume { get; set; }
        public double Deviation { get; set; }
        public Technician technician { get; set; }

        public Regulation(Technician technician, double actualAirVolume)
        {
            ActualAirVolume = actualAirVolume;
            this.technician = technician;
        }

    }
}
