using System;
using System.Collections.Generic;
using System.Text;

namespace PinsameGUI.Models
{
    public class OrderHistory
    {
        public string IDPhone { get; set; }
        private List<Pinsa> order;

        public List<Pinsa> Order
        {
            get { return order; }
            set { order = value; }
        }
        public int TotalPrice { get; set; }

        public OrderHistory(string pinsaName)
        {
            Pinsa item = new Pinsa();
            item.Name = pinsaName;
            Order.Add(item);
        }
    }
}
