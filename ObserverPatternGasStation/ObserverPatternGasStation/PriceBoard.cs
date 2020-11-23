using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPatternGasStation
{
    public class PriceBoard : IObserver
    {
        public double KeroOxygen { get; set; }
        public double HydroOxygen { get; set; }
        public double AlcoOxygen { get; set; }


        public void Update(ISubject subject)
        {

            if (subject is GasStation gs)
            {
                KeroOxygen = gs.KeroOxygen;
                AlcoOxygen = gs.AlcoOxygen;
                HydroOxygen = gs.HydroOxygen;
                Console.WriteLine($"{gs.Region} -> {gs.City}:\nKeroOxygen: {KeroOxygen:0.00},- HydroOxygen: {HydroOxygen:0.00},- AlcoOxygen: {AlcoOxygen:0.00},-\n");
            }
        }
    }
}
