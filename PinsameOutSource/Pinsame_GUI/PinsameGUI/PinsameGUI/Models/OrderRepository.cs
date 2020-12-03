using PinsameGUI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PinsameGUI.ViewModels
{
    /// <summary>
    /// Keeps all the information about the orders. This is used by the ViewModelLayer.
    /// </summary>
    public class OrderRepository
    {
        private ObservableCollection<Item> order = new ObservableCollection<Item>();

        public ObservableCollection<Item> Order
        {
            get { return order; }
            set { order = value; }
        }

        private List<Item> menuList = new List<Item>();
        public List<Item> MenuList
        {
            get { return menuList; }
        }

        private Item menuListSelectedItem;
        public Item MenuListSelectedItem
        {
            get { return menuListSelectedItem; }
            set { menuListSelectedItem = value; }
        }

        private Item orderListSelectedItem;

        public Item OrderListSelectedItem
        {
            get { return orderListSelectedItem; }
            set { orderListSelectedItem = value; }
        }

        public Item temporaryItem;

        public OrderRepository()
        {
            MenuListInitiator();
        }
        public void MenuListInitiator()
        {
            StreamReader sr = new StreamReader("MenuItems.txt");
            while(sr.EndOfStream == false)
            {
                string Line = sr.ReadLine();
                string[] Lines = Line.Split(';');
                Pinsa pinsa = new Pinsa();
                pinsa.Name = Lines[0];
                pinsa.Price = int.Parse(Lines[1]);
                menuList.Add(pinsa);
            }
            sr.Close();
        }
        public (int,double) WriteToOrderHistoryWithBonus(string number, double loyaltyPoints)
        {
            string newContent = number;
            int totalPrice = 0;

            foreach (Item item in order)
            {
                if (item is Pinsa pinsa)
                {
                    newContent += ";" + pinsa.Name;
                    totalPrice += pinsa.Price;
                }
                else if (item is Beverages beverage)
                {
                    newContent += ";" + beverage.Name;
                    totalPrice += beverage.Price;
                }
            }
            int totalPriceBeforeBonus = totalPrice;

            if (loyaltyPoints >= 100)
            {
                if (totalPrice >= 100)
                {
                    totalPrice -= 100;
                    loyaltyPoints -= 100;
                }
            }

            newContent += ";" + totalPrice + ";" + DateTime.Now;

            StreamReader sr = new StreamReader("OrderHistory.txt");
            string content = sr.ReadToEnd();
            sr.Close();

            StreamWriter sw = new StreamWriter("OrderHistory.txt");
            if (content.Length > 0)
            {
                sw.WriteLine(content + newContent);
            }
            else
            {
                sw.WriteLine(newContent);
            }
            sw.Close();
            return (totalPriceBeforeBonus, loyaltyPoints);
        }

        public int WriteToOrderHistory(string number)
        {
            string newContent = number;
            int totalPrice = 0;

            foreach (Item item in order)
            {
                if (item is Pinsa pinsa)
                {
                    newContent += ";" + pinsa.Name;
                    totalPrice += pinsa.Price;
                }
                else if (item is Beverages beverage)
                {
                    newContent += ";" + beverage.Name;
                    totalPrice += beverage.Price;
                }
            }
            int totalReturnPrice = totalPrice;

            newContent += ";" + totalPrice + ";" + DateTime.Now;

            StreamReader sr = new StreamReader("OrderHistory.txt");
            string content = sr.ReadToEnd();
            sr.Close();

            StreamWriter sw = new StreamWriter("OrderHistory.txt");
            if (content.Length > 0)
            {
                sw.WriteLine(content + newContent);
            }
            else
            {
                sw.WriteLine(newContent);
            }
            sw.Close();
            return totalReturnPrice;
        }


        private List<Item> dates = new List<Item>();

        public List<Item> Dates
        {
            get { return dates; }
            set { dates = value; }
        }

        public void HistoryInitiator(string phone)
        {
            order.Clear();
            dates.Clear();
            string Line = "";
            StreamReader sr = new StreamReader("OrderHistory.txt"); //Setup of txt = TelephoneNumber;OrderContent;TotalPrice
            while (sr.EndOfStream == false)
            {
                Line = sr.ReadLine();

                string[] Initiate = Line.Split(';'); //This splits the txt file single lines in strings
                if(Initiate[0] == phone)
                {
                    Pinsa Date = new Pinsa();
                    Date.Date = Initiate[Initiate.Length - 1];
                    Date.Price = int.Parse(Initiate[Initiate.Length - 2]);
                    Dates.Add(Date);
                    for (int i = 1; i < Initiate.Length - 2; i++)
                    {
                        Pinsa orderHistory = new Pinsa(); //Makes a new instance of the customer. Make sure that the txt file is correctly made or we will get expections here.
                        orderHistory.Date = Initiate[Initiate.Length - 1];
                        orderHistory.Name = Initiate[i];
                        Order.Add(orderHistory); //Adds the create instance to the customers list
                    }
                }
            }
            sr.Close();
        }
    }
}
