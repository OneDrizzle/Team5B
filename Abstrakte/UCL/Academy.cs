using System;
using System.Collections.Generic;

namespace UCL
{
    public delegate void NotifyHandler();
    public class Academy : Organization, ISubject
    {
        private string name;
        //private List<IObserver> students;

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; Notify(); }
        }


        public Academy(string name, string address) : base(name)
        {
            //students = new List<IObserver>();
            this.name = name;
            Address = address;
        }

        public void Attach(IObserver o)
        { students += o.Update; }
        public void Detach(IObserver o)
        { students -= o.Update; }
        public void Notify()
        {
            students();
        }

        private NotifyHandler students;    

    }
}
