using System;
using System.Collections.Generic;
using System.Text;

namespace Raketten
{
    public class GasStation
    {
        double KeroOxygenPrice;
        double HydroOxygenPrice;
        double AlcoOxygenPrice;
        double AlcoOxygendiscount;
        private GasCompany subject;

        public string PriceBoard;

        public string City;

        public string region;


        public double LocalDiscount()
        { return 5; }



        public double HydroOxygen()
        {
            double HydroOxygenPrice = (KeroOxygenPrice * 0.10);
            return HydroOxygenPrice;

        }
        public double KeroOxygen()
        {
            double KeroOxygenPrice = 9.32;
            return KeroOxygenPrice; 
        }

        public double AlcoOxygen()
        {
            double AlcoOxygendiscount = (KeroOxygenPrice * 0.10);
            AlcoOxygenPrice = (KeroOxygenPrice - AlcoOxygendiscount);
            return AlcoOxygenPrice;
        }

        public GasStation(GasCompany subject, string Region, string City)
        { }
        public void update()
        { }



    }
}
