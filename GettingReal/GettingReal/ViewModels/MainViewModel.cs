using GettingReal.Commands;
using GettingReal.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace GettingReal.ViewModels
{
    //[Serializable]
    public delegate CustomerEventArgs CustomerEventHandler(object sender, CustomerEventArgs args);
    public delegate BuildingEventArgs BuildingEventHandler(object sender, BuildingEventArgs args);
    public delegate void ItemSelectionEventHandler(object sender, ItemSelectionEventArgs args);
    public class MainViewModel : INotifyPropertyChanged
    {
        public ICommand NewCustomerCmd { get; } = new NewCustomerCmd();

        public event ItemSelectionEventHandler ItemsChanged;
        public event CustomerEventHandler NewCustomerRequested;
        public event BuildingEventHandler NewBuildingRequested;
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
            set
            { 
                _selectedVMBuilding = value;
                ct.SelectedBuilding = _selectedVMBuilding.GetBuilding();
                OnPropertyChanged("SelectedVMBuilding");
            }
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
            // Loads saved data from text file

            ct = Utility.BinaryDeserialize("Data123.txt") as Controller;
            if (ct == null)
            {
                ct = new Controller();
            }

            BuildingsVM = new ObservableCollection<VMBuilding>();
            RoomsVM = new ObservableCollection<VMRoom>();
            VentilationAggregatesVM = new ObservableCollection<VMVentilationAggregate>();
            CustomersVM = new ObservableCollection<VMCustomer>();
            FloorsVM = new ObservableCollection<VMFloor>();

            // If data was loaded and customers exist, VM moedls are made for each object

            if (ct.AllCustomers != null)
            {
                foreach (Customer customer in ct.AllCustomers)
                    CustomersVM.Add(new VMCustomer(customer));
            }
            
        }

        // Adds a new customer and calls to make a VM model for it, then adds it to list of customers and updates UI
        public void AddCustomer()
        {
            CustomerEventArgs e = OnNewCustomerRequested();
            if (e != null)
            {
                SelectedVMCustomer = new VMCustomer(ct.AddCustomer(e.Name, e.Company));
                CustomersVM.Add(SelectedVMCustomer);
                OnItemsChanged(SelectedVMCustomer);
            }
        }

        // Adds a new building and calls to make a VM model for it, then adds it to list of buildings and updates UI
        public void AddBuilding()
        {
            BuildingEventArgs e = OnNewBuildingRequested();
            if (e!=null)
            {
                VMBuilding b = new VMBuilding(ct.AddBuilding(e.Name));
                _selectedVMBuilding = b;
                BuildingsVM.Add(_selectedVMBuilding);
                OnItemsChanged(SelectedVMBuilding);
            }
            _selectedVMCustomer.AddBuilding(_selectedVMBuilding);
        }

        // Adds a new ventilationaggregate and calls to make a VM model for it, then adds it to list of ventilationaggregates
        public void AddVentilationAggregate(string fileName)
        {
            var agg = new VMVentilationAggregate(ct.AddVentilationAggregate());

            _selectedVMVentilationAggregate = agg;
            _selectedVMVentilationAggregate.FileName = fileName;
            //_selectedVMBuilding.AddVentilationAggregate(_selectedVMVentilationAggregate);
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

        protected BuildingEventArgs OnNewBuildingRequested()
        {
            BuildingEventArgs result = null;
            BuildingEventHandler newBuildingRequested = NewBuildingRequested;

            if (newBuildingRequested != null)
            {
                BuildingEventArgs args = null;
                result = newBuildingRequested(this, args);
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

        // Saves data to text file, using serialization
        public void Save()
        {
            Utility.BinarySerialize(ct, "Data123.txt");
        }

    }
}
