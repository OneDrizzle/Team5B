using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    public class Controller
    {
        
        public VentilationAggregate selectedAggregate { get; private set; }
        public Customer selectedCustomer { get; private set; }
        public Building selectedBuilding { get; private set; }
        public Room selectedRoom { get; private set; }
        private VentilationAggregateRepository aggregateRepository;
        private CustomerRepository customerRepository;
        private BuildingRepository buildingRepository;
        private RoomRepository roomRepository;

        private List<Building> allBuildings;
        private List<Room> allRooms;
        private List<VentilationAggregate> allVentilationAggregates;
        private List<Customer> allCustomers;

        public Controller()
        {
            aggregateRepository = new VentilationAggregateRepository();
            customerRepository = new CustomerRepository();
            buildingRepository = new BuildingRepository();
            roomRepository = new RoomRepository();

            allBuildings = new List<Building>();
            allRooms = new List<Room>();
            allVentilationAggregates = new List<VentilationAggregate>();
            allCustomers = new List<Customer>();
        }

        public void SelectVentilationAggregate(string orderNumber)
        {
            selectedAggregate = aggregateRepository.GetVentilationAggregate(orderNumber);
        }
        
        public void AddVentilationAggregate()
        { }

        public VentilationAggregate GetVentilationAggregate(string orderNumber)
        {
            foreach (VentilationAggregate ventilationAggregate in allVentilationAggregates)
            {
                if (ventilationAggregate.OrderNumber==orderNumber)
                {
                    return ventilationAggregate;
                }
            }
            return null;
        }
        
        public List<Filter> GetFilters(string orderNumber)
        {
            SelectVentilationAggregate(orderNumber);
            return aggregateRepository.GetListOfFilters(selectedAggregate);
        }

        public List<ServiceReport> GetServiceReports(string orderNumber)
        { }

        //public void AddAggregate(string modelNumber, string orderNumber, Customer customer)
        //{             
        //    VentilationAggregate aggregate = new VentilationAggregate();
        //    selectedAggregate = aggregate;
        //}


        //public void SelectAggregate(string orderNumber, string customer, string building)
        //{
        //    selectedAggregate = aggregateRepository.GetAggregate(orderNumber);           
        //    selectedBuilding.GetAggregate(orderNumber)
        //}

        //public void AddCustomer(string name, string company)
        //{
        //    Customer customer = new Customer();
        //    selectedCustomer = customer;
        //    customerRepository.AddCustomer(customer);
        //}


        // ************** ikke slet ****************
        //public void AddAggregate(string modelNumber, string orderNumber,
        //    string customerName, string companyName, string building, string floor, string room)
        //{
        //    Customer cust = new Customer(customerName, companyName, modelNumber,orderNumber,building,floor,room);
        //    selectedCustomer = cust;
        //    customerRepository.AddCustomer(cust);
        //}
        // *****************************************
        //public void getAllAggregatesForBuilding(String id)
        //{
        //    List<Aggregate> listOfAggregates;
        //    List<Room> listOfRooms = building.getRooms();
        //    foreach (Room room : listOfRooms)
        //    listOfAggregates.addAll(room.getAllAggregates());
        //}
        // *****************************************


    }
}
