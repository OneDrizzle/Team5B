using System;
using System.Collections.Generic;
using System.Text;

namespace UCL
{
    public interface INotifyMessageChanged
    {
        public event EventHandler MessageChanged;
    }
}
