using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPatternGasStation
{

    public enum FuelType
    {
        AlcoOxygen,
        KeroOxygen,
        HydroOxygen
    }

    public class GasPump : IObserver, ISubject
    {
        private List<IObserver> observers;
        private ISubject subject;
        public int Number { get; set; }
        public double Liters { get; set; }
        public string Status { get; set; }

        private bool paid;

        public bool Paid
        {
            get { return paid; }
            set { paid = value; Notify(); }
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
            paid = true;
            observers = new List<IObserver>();
            selectedFuelType = FuelType.HydroOxygen;
            Number = number;
            Status = "Klar til Brug";
        }

        public void SelectFuel(FuelType fuelType)
        {
            if (subject is GasStation gs)
            {
                selectedFuelType = fuelType;
                switch (selectedFuelType)
                {
                    case FuelType.AlcoOxygen:
                        price = gs.AlcoOxygen;
                        break;
                    case FuelType.KeroOxygen:
                        price = gs.KeroOxygen;
                        break;
                    case FuelType.HydroOxygen:
                        price = gs.HydroOxygen;
                        break;
                    default:
                        break;
                }
            }
        }

        public void Pump(double liters)
        {
            Liters = liters;
            Price = price * liters;
            Status = "Betal Påfyldning";
            Update(subject);
            Paid = false;
        }

        public void PaymentDone()
        {
            Liters = 0;
            price = 0;
            Status = "Klar til Brug";
            Update(subject);
            Paid = true;
        }

        public void Update(ISubject subject)
        {
            this.subject = subject;
            if (subject is GasStation gs)
            {

                Console.WriteLine($"{gs.Region} -> {gs.City}: Stander nr: {Number}\n" +
                    $"Valgt Brændstof: {selectedFuelType}\n" +
                    $"Antal Liter: {Liters}\n" +
                    $"Pris: {Price:0.00}\n" +
                    $"Status: {Status}\n" +
                    $"HydroOxygen: {gs.HydroOxygen:0.00},-\n" +
                    $"KeroOxygen: {gs.KeroOxygen:0.00},-\n" +
                    $"AlcoOxygen: {gs.AlcoOxygen:0.00},-\n");
            }
        }

        public void Attach(IObserver o)
        {
            observers.Add(o);
            o.Update(this);
            if (o is CardTerminal ct)
            {
                ct.AddSubject(this);
            }
        }

        public void Detach(IObserver o)
        {
            observers.Remove(o);
        }

        public void Notify()
        {
            foreach (var o in observers)
                o.Update(this);
        }
    }
}
