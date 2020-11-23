using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPatternGasStation
{
    public interface IObserver
    {
        void Update(ISubject subject);
    }
}
