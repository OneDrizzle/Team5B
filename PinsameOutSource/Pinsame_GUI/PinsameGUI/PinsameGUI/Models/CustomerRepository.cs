using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;
using System.ComponentModel;
using PinsameGUI.Models;

namespace PinsameGUI
{
    /// <summary>
    /// Keeps all the information about the customers. This is used by the ViewModelLayer.
    /// </summary>
    public class CustomerRepository
    {
        private List<OrderHistory> orderHistories;

        public List<OrderHistory> OrderHistories
        {
            get { return orderHistories; }
        }

        private List<Customer> customers = new List<Customer>();

        public List<Customer> Customers
        {
            get { return customers; }
        }
        public CustomerRepository()
        {
            CustomerInitiator();
        }

        public void CustomerInitiator()
        {
            string Line = "";
            StreamReader sr = new StreamReader("CustomerList.txt"); //Setup of txt = TelephoneNumber;Name;Mail;TotalPoints;TotalCost
            while (sr.EndOfStream == false)
            {
                Line = sr.ReadLine();

                string[] Initiate = Line.Split(';'); //This splits the txt file single lines in strings
                Customer customer = new Customer(Initiate[0], int.Parse(Initiate[1]), Initiate[2], double.Parse(Initiate[3]), int.Parse(Initiate[4])); //Makes a new instance of the customer. Make sure that the txt file is correctly made or we will get expections here.
                customers.Add(customer); //Adds the create instance to the customers list
            }
            sr.Close();
        }


        public Customer CreateCustomer(string newName, string newPhone, string newMail)
        {
            //Setup of txt = TelephoneNumber;Name;Mail;TotalPoints;TotalCost
            //Creates "Empty" instance of customer
            Customer customer = new Customer(newName, int.Parse(newPhone), newMail);
            customers.Add(customer);
            SaveList();
            return customer;
        }
        public void UpdateCustomer(string newName, string newPhone, string newMail, double points, double cost, int phone)
        {
            foreach (Customer customer in Customers)
            {
                if (customer.TelephoneNumber == phone)
                {
                    customer.Name = newName;
                    customer.TelephoneNumber = int.Parse(newPhone);
                    customer.Mail = newMail;
                    customer.TotalPoints = points;
                }
            }
        }

        public void UpdateCustomer(int phone, double newPoints)
        {
 
            foreach (Customer customer in customers)
            {
                if (phone == customer.TelephoneNumber)                 
                {
                    customer.TotalPoints = newPoints;
                }
            }
        }

        public void SaveList()
        {
            StreamWriter sw = new StreamWriter("CustomerList.txt"); //Setup of txt = TelephoneNumber;Name;Mail;TotalPoints;TotalCost
            foreach (Customer customer in customers)
            {
                sw.WriteLine(customer.Name + ";" + customer.TelephoneNumber + ";" + customer.Mail + ";" + customer.TotalPoints + ";" + customer.TotalCost);
            }
            sw.Close();
        }
        public void DeleteCustomer(int phone)
        {
            foreach (Customer customer in Customers)
            {
                if (customer.TelephoneNumber == phone)
                {
                    customers.Remove(customer);
                    break;
                }
            }
        }
    }
}
