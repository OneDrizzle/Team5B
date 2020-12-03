using System;
using System.Collections.Generic;
using System.Text;

namespace PinsameGUI.ViewModels
{
    /// <summary>
    /// Makes sure that the view needs of the models is modified, so it can be shown in the view layer.
    /// </summary>
    public class CustomerViewModel
    {
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Mail { get; set; }
        public double LoyaltyPoints { get; set; }
        public double TotalSpend { get; set; }
        public CustomerViewModel(Customer customer)
        {
            Name = customer.Name;
            Phone = customer.TelephoneNumber;
            Mail = customer.Mail;
            LoyaltyPoints = customer.TotalPoints;
            TotalSpend = customer.TotalCost;
        }
    }
}
