using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    public class CustomerRepository
    {

        List<Customer> customers;

        public CustomerRepository()
        {
            customers = new List<Customer>();
        }

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public Customer GetCustomer(string name)
        {
            foreach (Customer customer in customers)
            {
                if (customer.Name == name)
                {
                    return customer;
                }
            }
            return null;
        }
    }
}
