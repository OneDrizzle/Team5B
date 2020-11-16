using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    public class Regulation
    {

        public double MeasuredAirVolume { get; set; }
        public double Deviation { get; private set; }

        public Regulation(double measuredAirvolume)
        {
             MeasuredAirVolume = measuredAirvolume;
        }
        public Regulation() : this(-1)
        {
        }

    }
}
