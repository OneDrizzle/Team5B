using System;
using System.Collections.Generic;
using System.Text;

namespace ObsPtnGasStationDelegate
{
    public class PriceBoard : IObserver
    {
        public double KeroOxygen { get; set; }
        public double HydroOxygen { get; set; }
        public double AlcoOxygen { get; set; }
        public double Temperature { get; set; }
        public RegionType Region { get; set; }
        public string City { get; set; }

        public void Update(ISubject subject)
        {
            if (subject is GasStation gs)
            {
                KeroOxygen = gs.KeroOxygen;
                AlcoOxygen = gs.AlcoOxygen;
                HydroOxygen = gs.HydroOxygen;
                City = gs.City;
                Region = gs.Region;
            }

            if (subject is WeatherData wd)
            {
                Temperature = wd.Temperature;
            }

            Console.WriteLine($"{Region} -> {City}:\nKeroOxygen: {KeroOxygen:0.00},- HydroOxygen: {HydroOxygen:0.00},- AlcoOxygen: {AlcoOxygen:0.00},- Temperatur: {Temperature}");          
        }
    }
}
