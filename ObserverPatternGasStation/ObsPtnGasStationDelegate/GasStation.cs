using System;
using System.Collections.Generic;
using System.Text;

namespace ObsPtnGasStationDelegate
{
    public enum RegionType
    {
        Sjælland,
        Jylland,
        Fyn
    }

    public class GasStation : IObserver, ISubject
    {
        public NotifyHandler MessageChanged;

        private ISubject subject;

        private bool discount;
        public bool Discount 
        { 
            get { return discount; }
            set {
                    discount = value;
                    Update(subject);
                } 
        }

        private double keroOxygen;
        public double KeroOxygen
        {
            get { return keroOxygen; }
            set { keroOxygen = value; OnMessageChanged(); }
        }

        public double HydroOxygen
        {
            get { return KeroOxygen * 1.10; }
        }

        public double AlcoOxygen
        {
            get { return KeroOxygen * 0.90; }
        }

        public string City { get; set; }
        public RegionType Region { get; set; }

        public GasStation(RegionType region, string city)
        {
            discount = false;
            City = city;
            Region = region;
        }


        public void Update(ISubject subject)
        {
            this.subject = subject;
            if (subject is GasCompany gc)
            {
                keroOxygen = gc.BasePrice;

                if (Discount)
                {
                    keroOxygen = keroOxygen * 0.90;
                }

                switch (Region)
                {
                    case RegionType.Sjælland:
                        KeroOxygen = keroOxygen * 1.05;                     
                        break;

                    case RegionType.Fyn:
                        KeroOxygen = keroOxygen * 0.95;
                        break;

                    case RegionType.Jylland:
                        KeroOxygen = keroOxygen;
                        break;

                    default:
                        break;
                }
            }       
        }

        public void Attach(IObserver o)
        {
            if(o != null)
                MessageChanged += o.Update;
            OnMessageChanged();
        }

        public void Detach(IObserver o)
        {
            MessageChanged -= o.Update;
        }

        public void OnMessageChanged()
        {
            if (MessageChanged != null)
                MessageChanged(this);
            
        }

    }
}
