using System;
using System.Collections.Generic;
using System.Text;

namespace ObsPtnGasStationDelegate
{

    public enum FuelType
    {
        AlcoOxygen,
        KeroOxygen,
        HydroOxygen
    }

    public class GasPump : IObserver, ISubject
    {
        public NotifyHandler MessageChanged;
        private ISubject subject;

        public double HydroOxygen { get; set; }
        public double KeroOxygen { get; set; }
        public double AlcoOxygen { get; set; }

        public int Number { get; set; }
        public double Liters { get; set; }
        public string Status { get; set; }

        private bool paid;

        public bool Paid
        {
            get { return paid; }
            set { paid = value; OnMessageChanged(); }
        }

        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public FuelType selectedFuelType { get; set; }

        public GasPump(int number)
        {
            selectedFuelType = FuelType.HydroOxygen;
            Number = number;
            Status = "Klar til Brug";
            paid = true;
        }

        public void SelectFuel(FuelType fuelType)
        {
            if (subject is GasStation gs)
            {
                selectedFuelType = fuelType;
                switch (selectedFuelType)
                {
                    case FuelType.AlcoOxygen:
                        price = AlcoOxygen;
                        break;
                    case FuelType.KeroOxygen:
                        price = KeroOxygen;
                        break;
                    case FuelType.HydroOxygen:
                        price = HydroOxygen;
                        break;
                    default:
                        break;
                }
            }
        }

        public void Pump(double liters)
        {
            Liters = liters;
            Price = price * Liters;
            Status = "Betal Påfyldning";
            Update(this.subject);
            Paid = false;
        }

        public void PaymentDone()
        {
            Liters = 0;
            price = 0;
            Status = "Klar til Brug";
            Update(this.subject);
            Paid = true;
        }

        public void Update(ISubject subject)
        {
            this.subject = subject;
            if (subject is GasStation gs)
            {
                HydroOxygen = gs.HydroOxygen;
                KeroOxygen = gs.KeroOxygen;
                AlcoOxygen = gs.AlcoOxygen;

                Console.WriteLine($"{gs.Region} -> {gs.City}: Stander nr: {Number}\n" +
                    $"Valgt Brændstof: {selectedFuelType}\n" +
                    $"Antal Liter: {Liters}\n" +
                    $"Pris: {Price:0.00}\n" +
                    $"Status: {Status}\n" +
                    $"HydroOxygen: {HydroOxygen:0.00},-\n" +
                    $"KeroOxygen: {KeroOxygen:0.00},-\n" +
                    $"AlcoOxygen: {AlcoOxygen:0.00},-\n");
            }
        }

        public void Attach(IObserver o)
        {
            MessageChanged += o.Update;
            if (o is CardTerminal ct)
            {
                ct.AddSubject(this);
            }

        }

        public void Detach(IObserver o)
        {
            MessageChanged -= o.Update;
        }

        public void OnMessageChanged()
        {
            MessageChanged(this);
        }

    }
}
