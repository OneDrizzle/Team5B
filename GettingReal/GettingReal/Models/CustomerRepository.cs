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

        public void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }

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

        public List<Customer> GetAllCustomers()
        {
            return _customers;
        }

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
