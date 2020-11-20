using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal.Models
{
    [Serializable]
    public class CustomerRepository
    {

        List<Customer> _customers;

        public CustomerRepository()
        {
            _customers = new List<Customer>();
        }

        // Adds a customer to the customer list
        public void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }

        // Retrieves a specific customer by name
        public Customer GetCustomer(string name)
        {
            foreach (Customer customer in _customers)
            {
                if (customer.Name == name)
                {
                    return customer;
                }
            }
            return null;
        }

        // Gets a list of all customers
        public List<Customer> GetAllCustomers()
        {
            return _customers;
        }

        // Sets the selected customer
        public void SetCustomer(string name)
        {
            Customer selectedCustomer;

            foreach (Customer customer in _customers)
            {
                if (customer.Name == name)
                {
                    selectedCustomer = customer;
                }
            }
        }

        public void DeleteCustomer()
        { }
    }
}
