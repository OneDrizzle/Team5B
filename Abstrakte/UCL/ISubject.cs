using System;
using System.Collections.Generic;
using System.Text;

namespace UCL
{
    public interface ISubject
    {
        public void Attach(IObserver o)
        { }
        public void Detach(IObserver o)
        { }
        public virtual void Notify()
        { }
    }
}
