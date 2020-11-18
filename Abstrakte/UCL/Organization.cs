using System;
using System.Collections.Generic;
using System.Text;

namespace UCL
{
    public class Organization
    {

        private string name;
        private string address;

        public string Name
        {
            get { return name; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public Organization(string name)
        { 
            this.name = name;
        }





    }
}
