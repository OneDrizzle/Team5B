using System;
using System.Collections.Generic;
using System.Text;

namespace ObsPtnGasStationDelegate
{
    public class WeatherData : ISubject
    {

        public NotifyHandler MessageChanged;

        private double temperature;

        public double Temperature
        {
            get { return temperature; }
            set { temperature = value; OnMessageChanged(); }
        }

        public WeatherData()
        {
        }

        public void Attach(IObserver o)
        {
            MessageChanged += o.Update;    
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
