using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    public class Controller
    {
        
        public Aggregate selectedAggregate { get; private set; }
        public Technician selectedTechnician { get; private set; }
        public Customer selectedCustomer { get; private set; }
        public Building selectedBuilding { get; private set; }
        public Floor selectedFloor { get; private set; }
        public Room selectedRoom { get; private set; }
        private AggregateRepository aggregateRepository;
        private CustomerRepository customerRepository;
        private BuildingRepository buildingRepository;

        public Controller()
        {
            aggregateRepository = new AggregateRepository();
            customerRepository = new CustomerRepository();
            buildingRepository = new BuildingRepository();
        }

        public void AddAggregate(string modelNumber, string orderNumber, Customer customer)
        {             
            Aggregate aggregate = new Aggregate();
            selectedAggregate = aggregate;
            aggregateRepository.AddAggregate(modelNumber, orderNumber, customer);
        }


        // ************** ikke slet ****************
        //public void AddAggregate(string modelNumber, string orderNumber,
        //    string customerName, string companyName, string building, string floor, string room)
        //{
        //    Customer cust = new Customer(customerName, companyName, modelNumber,orderNumber,building,floor,room);
        //    selectedCustomer = cust;
        //    customerRepository.AddCustomer(cust);
        //}



        public void selectAggregate(string orderNumber)
        {
            selectedAggregate = aggregateRepository.GetAggregate(orderNumber);           
        }

        public void AddCustomer(string name, string company)
        {
            Customer customer = new Customer();
            selectedCustomer = customer;
            customerRepository.AddCustomer(customer);
        }


    }
}
