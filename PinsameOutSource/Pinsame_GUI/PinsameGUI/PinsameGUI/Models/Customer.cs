using System;
using System.Collections.Generic;
using System.Text;

namespace PinsameGUI
{
    public class Customer
    {
        public string Name { get; set; }
        public int TelephoneNumber { get; set; }
        public string Mail { get; set; }
        public double TotalPoints { get; set; }
        public double TotalCost { get; set; }


        public Customer(string name, int telephoneNumber, string mail, double totalPoints, double totalCost)
        {
            Name = name;
            TelephoneNumber = telephoneNumber;
            Mail = mail;
            TotalPoints = totalPoints;
            TotalCost = totalCost;
        }
        public Customer(string name, int telephoneNumber, string mail, double totalPoints) : this(name, telephoneNumber, mail, totalPoints, 0) { }
        public Customer(string name, int telephoneNumber, string mail) : this(name, telephoneNumber, mail, 0, 0) { }
        public Customer(string name, int telephoneNumber) : this(name, telephoneNumber, "", 0, 0) { }
        public Customer(int telephoneNumber) : this("", telephoneNumber, "", 0, 0) { }


    }
}
