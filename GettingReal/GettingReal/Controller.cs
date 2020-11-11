using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    public class Controller
    {
        
        public VentilationAggregate selectedVentilationAggregate { get; private set; }
        public Customer selectedCustomer { get; private set; }
        public Building selectedBuilding { get; private set; }
        public Room selectedRoom { get; private set; }

        private VentilationAggregateRepository ventilationAggregateRepository;
        private CustomerRepository customerRepository;
        private BuildingRepository buildingRepository;
        private RoomRepository roomRepository;

        private List<Building> allBuildings;
        private List<Room> allRooms;
        private List<VentilationAggregate> allVentilationAggregates;
        private List<Customer> allCustomers;

        public Controller()
        {
            ventilationAggregateRepository = new VentilationAggregateRepository();
            customerRepository = new CustomerRepository();
            buildingRepository = new BuildingRepository();
            roomRepository = new RoomRepository();

            allCustomers = customerRepository.GetAllCustomers();
            allBuildings = buildingRepository.GetAllBuildings();
            allVentilationAggregates = ventilationAggregateRepository.GetAllVentilationAggregates();
            allRooms = roomRepository.GetAllRooms();
           
        }

        public void SelectVentilationAggregate(string orderNumber)
        {
            selectedVentilationAggregate = ventilationAggregateRepository.GetVentilationAggregate(orderNumber);
        }
        
        public bool AddVentilationAggregate(string orderNumber)
        {

            foreach (VentilationAggregate aggregate in allVentilationAggregates)
            {
                if (aggregate.OrderNumber == orderNumber)
                {
                    return false;
                }
            }
            ventilationAggregateRepository.AddVentilationAggregate(orderNumber);
            return true;
        }

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
            return selectedVentilationAggregate.GetListOfFilters();
        }

        public List<ServiceReport> GetServiceReports(string orderNumber)
        {
            SelectVentilationAggregate(orderNumber);
            return selectedVentilationAggregate.GetListOfServiceReports();
        }

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
