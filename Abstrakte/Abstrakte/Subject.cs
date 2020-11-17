using System;
using System.Collections.Generic;
using System.Text;

namespace Abstrakte
{
    public abstract class Subject
    {
        private List<Observer> observers;

        public void Attach(Observer o)
        { observers.Add(o); }
        public void Detach(Observer o)
        { observers.Remove(o); }
        public virtual void Notify()
        { }

        public Subject()
        {
            observers = new List<Observer>();
        }
        public List<Observer> Observers => observers;

    }
}
