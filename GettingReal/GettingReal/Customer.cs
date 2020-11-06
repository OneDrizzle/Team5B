using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    public class Customer
    {
        public string Name { get; set; }
        public string Company { get; set; }

        public Customer(string name = "", string company = "")
        {
            Name = name;
            Company = company;
        }
    }
}
