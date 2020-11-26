using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal.ViewModels
{
    public class CustomerEventArgs : EventArgs
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _company;
        public string Company
        {
            get { return _company; }
            set { _company = value; }
        }
    }
}
