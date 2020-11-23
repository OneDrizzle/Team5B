using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace UCL
{

    public class Academy : Organization, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string name;
        //private List<IObserver> students;

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnMessageChanged(); }
        }


        public Academy(string name, string address) : base(name)
        {
            //students = new List<IObserver>();
            this.name = name;
            Address = address;
        }

        

        //public void Attach(IObserver o)
        //{ students += o.Update; }
        //public void Detach(IObserver o)
        //{ students -= o.Update; }
        public void OnMessageChanged()
        {
            PropertyChanged(this, null);
        }
    }
}
