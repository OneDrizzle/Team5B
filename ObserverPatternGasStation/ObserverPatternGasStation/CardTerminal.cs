using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPatternGasStation
{
    public class CardTerminal : IObserver
    {
        private List<ISubject> subjects;
        private ISubject selectedSubject;

        public CardTerminal()
        {
            subjects = new List<ISubject>();
        }

        public void AddSubject(ISubject s)
        {
            subjects.Add(s);
        }

        public void PayFilling(int number)
        {
            foreach (ISubject s in subjects)
            {
                if (s is GasPump gp)
                {
                    if (gp.Number == number)
                    {
                        gp.PaymentDone();
                    }
                }
            }
        }

        public void Update(ISubject subject)
        {
            selectedSubject = subject;

            bool allPaid = true;
            Console.WriteLine("Betalingsautomat:");
            foreach (ISubject s in subjects)
            {
                if (s is GasPump gp)
                {
                    if (!gp.Paid)
                    {   
                        Console.WriteLine($"Stander {gp.Number}: {gp.Liters} liter {gp.selectedFuelType} til {gp.Price:0.00}");
                        allPaid = false;
                    }
                }
            }
            if(allPaid)
            {
                Console.WriteLine("Alt betalt");
            }
            Console.WriteLine();
            
        }
    }
}
