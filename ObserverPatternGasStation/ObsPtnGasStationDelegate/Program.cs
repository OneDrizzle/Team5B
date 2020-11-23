﻿using System;

namespace ObsPtnGasStationDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            var rocketFuel = new GasCompany();

            var gs1 = new GasStation(RegionType.Sjælland, "København");
            var gs2 = new GasStation(RegionType.Fyn, "Odense");
            var gs3 = new GasStation(RegionType.Jylland, "Århus");

            var pb1 = new PriceBoard();
            var pb2 = new PriceBoard();
            var pb3 = new PriceBoard();

            var wd1 = new WeatherData();
            var wd2 = new WeatherData();
            var wd3 = new WeatherData();

            var gp1 = new GasPump(1);
            var gp2 = new GasPump(2);
            var gp3 = new GasPump(3);

            var ct = new CardTerminal();

            rocketFuel.Attach(gs1);
            rocketFuel.Attach(gs2);
            rocketFuel.Attach(gs3);

            rocketFuel.BasePrice = 90;

            Console.WriteLine("Tilknyt lysskilt til tankstation:");
            gs1.Attach(pb1);
            wd1.Attach(pb1);
            wd1.Temperature = 15;
            Console.WriteLine();
            Console.WriteLine("Tilknyt lysskilt til tankstation:");
            gs2.Attach(pb2);
            wd2.Attach(pb2);
            wd2.Temperature = 20;
            Console.WriteLine();
            Console.WriteLine("Tilknyt lysskilt til tankstation:");
            gs3.Attach(pb3);
            wd3.Attach(pb3);
            wd3.Temperature = 10;
            Console.WriteLine();

            Console.WriteLine($"Opdatér selskabets basispris til {100} kr:");
            rocketFuel.BasePrice = 100;
            Console.WriteLine();
            Console.WriteLine($"Opdatér selskabets basispris til {105} kr:");
            rocketFuel.BasePrice = 105;
            Console.WriteLine();
            Console.WriteLine($"Opdatér selskabets basispris til {95} kr:");
            rocketFuel.BasePrice = 95;
            Console.WriteLine();

            Console.WriteLine($"Sæt rabat på tankstation i {gs2.City}:");
            gs2.Discount = true;
            Console.WriteLine();

            Console.WriteLine($"Opdatér selskabets basispris til {100} kr:");
            rocketFuel.BasePrice = 100;
            Console.WriteLine();

            Console.WriteLine($"Fjern rabat på tankstation i {gs2.City}:");
            gs2.Discount = false;
            Console.WriteLine();



            Console.WriteLine("Tilknyt stander 1 til tankstation:");
            gs1.Attach(gp1);
            Console.WriteLine();
            Console.WriteLine("Tilknyt stander 2 til tankstation:");
            gs1.Attach(gp2);
            Console.WriteLine();
            Console.WriteLine("Tilknyt stander 3 til tankstation:");
            gs1.Attach(gp3);
            Console.WriteLine();


            Console.WriteLine("Tilknyt stander 1 til betalingsautomat:");
            gp1.Attach(ct);
            Console.WriteLine();
            Console.WriteLine("Tilknyt stander 2 til betalingsautomat:");
            gp2.Attach(ct);
            Console.WriteLine();
            Console.WriteLine("Tilknyt stander 3 til betalingsautomat:");
            gp3.Attach(ct);
            Console.WriteLine();

            Console.WriteLine($"Vælg AlcoOxygen på stander 1 og tank 45 liter:");
            gp1.SelectFuel(FuelType.AlcoOxygen);
            gp1.Pump(45.0);
            Console.WriteLine();

            Console.WriteLine($"Opdatér selskabets basispris til {110} kr:");
            rocketFuel.BasePrice = 110;
            Console.WriteLine();

            Console.WriteLine($"Vælg HydroOxygen på stander 3 og tank 32 liter:");
            gp3.SelectFuel(FuelType.HydroOxygen);
            gp3.Pump(32.0);
            Console.WriteLine();

            Console.WriteLine($"Betal regning på stander 1:");
            ct.PayFilling(1);
            Console.WriteLine();

            Console.WriteLine($"Betal regning på stander 3:");
            ct.PayFilling(3);
            Console.WriteLine();

        }

    }
}
