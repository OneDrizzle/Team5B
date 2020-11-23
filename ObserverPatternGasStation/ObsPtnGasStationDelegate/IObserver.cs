using System;
using System.Collections.Generic;
using System.Text;

namespace ObsPtnGasStationDelegate
{
    public interface IObserver
    {
        void Update(ISubject subject);
    }
}
