﻿using GettingReal.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GettingReal.ViewModels
{
    [Serializable]
    public class MainViewModel : INotifyPropertyChanged
    {
        private VMCustomer _selectedVMCustomer;
        public VMCustomer SelectedVMCustomer
        {
            get { return _selectedVMCustomer; }
            set 
            {
                _selectedVMCustomer = value; 
                ct.SelectedCustomer = _selectedVMCustomer.GetCustomer();
                OnPropertyChanged("SelectedVMCustomer");
            }
        }

        private VMBuilding _selectedVMBuilding;
        public VMBuilding SelectedVMBuilding
        {
            get { return _selectedVMBuilding; }
            set { _selectedVMBuilding = value; ct.SelectedBuilding = _selectedVMBuilding.GetBuilding(); }
        }

        private VMVentilationAggregate _selectedVMVentilationAggregate;
        public VMVentilationAggregate SelectedVMVentilationAggregate
        {
            get { return _selectedVMVentilationAggregate; }
            set { _selectedVMVentilationAggregate = value; ct.SelectedVentilationAggregate = _selectedVMVentilationAggregate.GetVentilationAggregate(); }
        }

        private VMRoom _selectedVMRoom;
        public VMRoom SelectedVMRoom
        {
            get { return _selectedVMRoom; }
            set { _selectedVMRoom = value; ct.SelectedRoom = _selectedVMRoom.GetRoom(); }
        }

        private VMFloor _selectedVMFloor;
        public VMFloor SelectedVMFloor
        {
            get { return _selectedVMFloor; }
            set { _selectedVMFloor = value; ct.SelectedFloor = _selectedVMFloor.GetFloor(); }
        }

        public ObservableCollection<VMBuilding> BuildingsVM { get; set; }
        public ObservableCollection<VMRoom> RoomsVM { get; set; }
        public ObservableCollection<VMVentilationAggregate> VentilationAggregatesVM { get; set; }
        public ObservableCollection<VMCustomer> CustomersVM { get; set; }
        public ObservableCollection<VMFloor> FloorsVM { get; set; }

        Controller ct;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            BuildingsVM = new ObservableCollection<VMBuilding>();
            RoomsVM = new ObservableCollection<VMRoom>();
            VentilationAggregatesVM = new ObservableCollection<VMVentilationAggregate>();
            CustomersVM = new ObservableCollection<VMCustomer>();
            FloorsVM = new ObservableCollection<VMFloor>();

            ct = Utility.BinaryDeserialize("Database\\Data.txt") as Controller;

            if (ct == null)
            {
                ct = new Controller();
            }
            if (ct.AllCustomers != null)
            {
                foreach (Customer customer in ct.AllCustomers)
                    CustomersVM.Add(new VMCustomer(customer));
            }

        }

        //public void SelectVentilationAggregate(string orderNumber)
        //{
        //    _selectedVMVentilationAggregate = _selectedVMBuilding.GetVentilationAggregateVM(orderNumber);
        //}


        public void AddCustomer()
        {
            VMCustomer c = new VMCustomer(ct.AddCustomer());
            _selectedVMCustomer = c;
            CustomersVM.Add(_selectedVMCustomer);
        }
        public void AddBuilding()
        {
            _selectedVMBuilding = new VMBuilding(ct.AddBuilding());
            _selectedVMCustomer.AddBuilding(_selectedVMBuilding);
        }
        public void AddVentilationAggregate(string fileName)
        {
            var agg = new VMVentilationAggregate(ct.AddVentilationAggregate());

            _selectedVMVentilationAggregate = agg;
            _selectedVMVentilationAggregate.FileName = fileName;
            _selectedVMBuilding.AddVentilationAggregate(_selectedVMVentilationAggregate);
        }
        public void AddFloor()
        {
            _selectedVMFloor = new VMFloor(ct.AddFloor());
            _selectedVMVentilationAggregate.AddFloor(_selectedVMFloor);
        }

        public void AddRoom()
        {
            _selectedVMRoom = new VMRoom(ct.AddRoom());
            _selectedVMFloor.AddRoom(_selectedVMRoom);
        }

        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }



        //public void AddVentilationAggregate()
        //{
        //    //filename = vodoo;
        //    ct.NewAgrete;
        //    _selectedVMVentilationAggregate = new VMVentilationAggregate(ct.AddVentilationAggregate());
        //    _ventilationAggregatesVM.Add(_selectedVMVentilationAggregate);
        //}

        //public VentilationAggregate GetVentilationAggregateList(string orderNumber)         //****Ændret til list, den skal nu returnerer listen af aggregater der tilhører dette ordrenummer****DELETE THIS COMMENT WHEN DONE
        //{
        //    foreach (VentilationAggregate ventilationAggregate in _allVentilationAggregates)
        //    {
        //        if (ventilationAggregate.OrderNumber == orderNumber)
        //        {
        //            return ventilationAggregate;
        //        }
        //    }
        //    return null;
        //}

        //public List<Filter> GetFilters(string orderNumber)
        //{
        //    SelectVentilationAggregate(orderNumber);
        //    return _selectedVentilationAggregate.GetListOfFilters();
        //}

        //public List<ServiceReport> GetServiceReports(string orderNumber)
        //{
        //    SelectVentilationAggregate(orderNumber);
        //    return _selectedVentilationAggregate.GetListOfServiceReports();
        //}

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
