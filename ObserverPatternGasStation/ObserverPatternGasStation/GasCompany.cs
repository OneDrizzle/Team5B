using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPatternGasStation
{
    public class GasCompany : ISubject
    {
        private double basePrice;

        private List<IObserver> observers;

        public GasCompany()
        {
            observers = new List<IObserver>();
        }

        public double BasePrice
        {
            get { return basePrice; }
            set { basePrice = value; Notify(); }
        }

        public void Attach(IObserver o)
        {
            observers.Add(o);
            o.Update(this);
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
