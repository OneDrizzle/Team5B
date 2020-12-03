using PinsameGUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PinsameGUI.ViewModels
{
    /// <summary>
    /// Makes sure that the view needs of the models is modified, so it can be shown in the view layer.
    /// </summary>
    public class OrderViewModel
    {
        private int count = 0;
        public int OrderItemNumber { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public OrderViewModel(Item item)
        {
            Pinsa i = (Pinsa)item;
            Name = i.Name;
            Price = i.Price;
        }

        public OrderViewModel(OrderViewModel orderViewModel)
        {
            count++;
            OrderItemNumber = count;
            Name = orderViewModel.Name;
            Price = orderViewModel.Price;
        }
    }
}
