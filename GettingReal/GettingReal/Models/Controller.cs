using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal.Models
{
    [Serializable]
    public class Controller
    {
        public VentilationAggregate SelectedVentilationAggregate { get; set; }
        public Customer SelectedCustomer { get; set; }
        public Building SelectedBuilding { get; set; }
        public Room SelectedRoom { get; set; }

        private VentilationAggregateRepository _ventilationAggregateRepository;
        private CustomerRepository _customerRepository;
        private BuildingRepository _buildingRepository;
        private RoomRepository _roomRepository;

        public List<VentilationAggregate> AllVentilationAggregates { get; private set; }
        public List<Building> AllBuildings { get; private set; }
        public List<Room> AllRooms { get; private set; }
        public List<Customer> AllCustomers { get; private set; }

        public Controller()
        {
            _ventilationAggregateRepository = new VentilationAggregateRepository();
            _customerRepository = new CustomerRepository();
            _buildingRepository = new BuildingRepository();
            _roomRepository = new RoomRepository();

            AllCustomers = _customerRepository.GetAllCustomers();
            AllBuildings = _buildingRepository.GetAllBuildings();
            AllVentilationAggregates = _ventilationAggregateRepository.GetAllVentilationAggregates();
            AllRooms = _roomRepository.GetAllRooms();
        }

        public void SelectVentilationAggregate(string orderNumber)
        {
            SelectedVentilationAggregate = _ventilationAggregateRepository.GetVentilationAggregate(orderNumber);
        }

        public Building AddBuilding()
        {
            SelectedBuilding = new Building();
            _buildingRepository.AddBuilding(SelectedBuilding);
            SelectedCustomer.AddBuilding(SelectedBuilding);
            return SelectedBuilding;
        }
        
        public Customer AddCustomer()
        {
            SelectedCustomer = new Customer();
            _customerRepository.AddCustomer(SelectedCustomer);
            return SelectedCustomer;
        }

        public void AddTest(string customer, string building, string aggregate)
        {
            var c = new Customer(name: customer);
            SelectedCustomer = c;
            _customerRepository.AddCustomer(c);
            var b = new Building(name: building);
            SelectedBuilding = b;
            SelectedCustomer.AddBuilding(b);
            _buildingRepository.AddBuilding(b);
            var ag1 = new VentilationAggregate(orderNumber: aggregate);
            //var ag2 = new VentilationAggregate("666");
            SelectedBuilding.AddVentilationAggregate(ag1);
            //selectedBuilding.AddVentilationAggregate(ag2);
            _ventilationAggregateRepository.AddVentilationAggregate(ag1);
            //ventilationAggregateRepository.AddVentilationAggregate(ag2);
        }

        public void Show()
        {
            AllCustomers = _customerRepository.GetAllCustomers();

            foreach (Customer customer in AllCustomers)
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

        public VentilationAggregate AddVentilationAggregate(string orderNumber, string FileName)
        {
            //foreach (VentilationAggregate aggregate in _allVentilationAggregates)
            //{
            //    if (aggregate.OrderNumber == orderNumber)
            //    {
            //        return false;
            //    }
            //}
            SelectedVentilationAggregate = _ventilationAggregateRepository.AddVentilationAggregate(orderNumber, FileName);
            return SelectedVentilationAggregate;
            //return true;
        }

        public VentilationAggregate GetVentilationAggregateList(string orderNumber)         //****Ændret til list, den skal nu returnerer listen af aggregater der tilhører dette ordrenummer****DELETE THIS COMMENT WHEN DONE
        {
            foreach (VentilationAggregate ventilationAggregate in AllVentilationAggregates)
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
            return SelectedVentilationAggregate.GetListOfFilters();
        }

        public List<ServiceReport> GetServiceReports(string orderNumber)
        {
            SelectVentilationAggregate(orderNumber);
            return SelectedVentilationAggregate.GetListOfServiceReports();
        }
    }
}
