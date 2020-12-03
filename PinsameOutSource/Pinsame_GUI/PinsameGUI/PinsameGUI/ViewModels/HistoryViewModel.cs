using PinsameGUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PinsameGUI.ViewModels
{
    /// <summary>
    /// Makes sure that the view needs of the models is modified, so it can be shown in the view layer.
    /// </summary>
    public class HistoryViewModel
    {
        public string Date { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public HistoryViewModel(Item dateOrHistory)
        {
            Pinsa p = (Pinsa)dateOrHistory;
            Date = p.Date;
            Name = p.Name;
            Price = p.Price;
        }
    }
}
