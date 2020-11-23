using System;
using System.Collections.Generic;
using System.Text;

namespace ObsPtnGasStationDelegate
{
    public delegate void NotifyHandler(ISubject subject);
    public class GasCompany : ISubject
    {

        public NotifyHandler MessageChanged;

        private double basePrice = 90;

        public double BasePrice
        {
            get { return basePrice; }
            set { basePrice = value; OnMessageChanged(); }
        }


        public void Attach(IObserver o)
        {
            MessageChanged += o.Update;
            OnMessageChanged();
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
