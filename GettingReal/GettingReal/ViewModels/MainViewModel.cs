using System;
using System.Collections.Generic;
using System.Text;
using GettingReal.Models;

namespace GettingReal.ViewModels
{
    [Serializable]
    public class MainViewModel
    {
        private VentilationAggregate _selectedVentilationAggregate;
        private Customer _selectedCustomer;
        private Building _selectedBuilding;
        private Room _selectedRoom;

        private VentilationAggregateRepository _ventilationAggregateRepository;
        private CustomerRepository _customerRepository;
        private BuildingRepository _buildingRepository;
        private RoomRepository _roomRepository;

        private List<Building> _allBuildings;
        private List<Room> _allRooms;
        private List<VentilationAggregate> _allVentilationAggregates;
        private List<Customer> _allCustomers;

        public MainViewModel()
        {
            _ventilationAggregateRepository = new VentilationAggregateRepository();
            _customerRepository = new CustomerRepository();
            _buildingRepository = new BuildingRepository();
            _roomRepository = new RoomRepository();

            _allCustomers = _customerRepository.GetAllCustomers();
            _allBuildings = _buildingRepository.GetAllBuildings();
            _allVentilationAggregates = _ventilationAggregateRepository.GetAllVentilationAggregates();
            _allRooms = _roomRepository.GetAllRooms();
        }

        public void SelectVentilationAggregate(string orderNumber)
        {
            _selectedVentilationAggregate = _ventilationAggregateRepository.GetVentilationAggregate(orderNumber);
        }

        public void AddTest(string customer, string building, string aggregate)
        {
            var c = new Customer(name: customer);
            _selectedCustomer = c;
            _customerRepository.AddCustomer(c);
            var b = new Building(name: building);
            _selectedBuilding = b;
            _selectedCustomer.AddBuilding(b);
            _buildingRepository.AddBuilding(b);
            var ag1 = new VentilationAggregate(orderNumber: aggregate);
            //var ag2 = new VentilationAggregate("666");
            _selectedBuilding.AddVentilationAggregate(ag1);
            //selectedBuilding.AddVentilationAggregate(ag2);
            _ventilationAggregateRepository.AddVentilationAggregate(ag1);
            //ventilationAggregateRepository.AddVentilationAggregate(ag2);
        }

        public void Show()
        {
            _allCustomers = _customerRepository.GetAllCustomers();

            foreach (Customer customer in _allCustomers)
            {
                Console.WriteLine(customer.ToString());
                foreach (Building building in customer.GetListOfBuildings())
                {
                    Console.WriteLine(building.ToString());
                    foreach (VentilationAggregate aggregate in building.GetListOfVentilationAggregates())
                    {
                        Console.WriteLine(aggregate.ToString());
                    }
                }
            }
            Console.WriteLine();
        }
        public void Show2()
        {
            foreach (Customer customer in _customerRepository.GetAllCustomers())
                Console.WriteLine(customer.ToString());

            foreach (Building building in _buildingRepository.GetAllBuildings())
                Console.WriteLine(building.ToString());

            foreach (VentilationAggregate aggregate in _ventilationAggregateRepository.GetAllVentilationAggregates())
                Console.WriteLine(aggregate.ToString());

            Console.WriteLine();
        }

        public bool AddVentilationAggregate(string orderNumber)
        {
            foreach (VentilationAggregate aggregate in _allVentilationAggregates)
            {
                if (aggregate.OrderNumber == orderNumber)
                {
                    return false;
                }
            }
            _ventilationAggregateRepository.AddVentilationAggregate(orderNumber);
            return true;
        }

        public VentilationAggregate GetVentilationAggregate(string orderNumber)
        {
            foreach (VentilationAggregate ventilationAggregate in _allVentilationAggregates)
            {
                if (ventilationAggregate.OrderNumber == orderNumber)
                {
                    return ventilationAggregate;
                }
            }
            return null;
        }

        public List<Filter> GetFilters(string orderNumber)
        {
            SelectVentilationAggregate(orderNumber);
            return _selectedVentilationAggregate.GetListOfFilters();
        }

        public List<ServiceReport> GetServiceReports(string orderNumber)
        {
            SelectVentilationAggregate(orderNumber);
            return _selectedVentilationAggregate.GetListOfServiceReports();
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
