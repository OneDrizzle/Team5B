﻿using GettingReal.Commands;
using GettingReal.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace GettingReal.ViewModels
{
    [Serializable]
    public delegate CustomerEventArgs CustomerEventHandler(object sender, CustomerEventArgs args);
    public delegate void ItemSelectionEventHandler(object sender, ItemSelectionEventArgs args);
    public class MainViewModel : INotifyPropertyChanged
    {
        public ICommand NewCustomerCmd { get; } = new NewCustomerCmd();

        public event ItemSelectionEventHandler ItemsChanged;
        public event CustomerEventHandler NewCustomerRequested;
        public event PropertyChangedEventHandler PropertyChanged;

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

        public void AddCustomer()
        {
            CustomerEventArgs e = OnNewCustomerRequested();
            if (e != null)
            {
                VMCustomer c = new VMCustomer(ct.AddCustomer(e.Name, e.Company));
                _selectedVMCustomer = c;
                CustomersVM.Add(_selectedVMCustomer);
                OnItemsChanged(SelectedVMCustomer);
            }
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
        
        protected CustomerEventArgs OnNewCustomerRequested()
        {
            CustomerEventArgs result = null;
            CustomerEventHandler newCustomerRequested = NewCustomerRequested;

            if (newCustomerRequested != null)
            {
                CustomerEventArgs args = null;
                result = newCustomerRequested(this, args);
            }
            return result;
        }

        protected void OnItemsChanged(object selectedItem)
        {
            if (ItemsChanged != null)
            {
                ItemsChanged(this, new ItemSelectionEventArgs(selectedItem));
            }
        }

    }
}