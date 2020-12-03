using PinsameGUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PinsameGUI.ViewModels
{
    public class MainViewModel
    {
        /// <summary>
        /// This MainViewModel is the only ViewModel that has any communication with the view layer. It communicates to three parts of the view layer using different methods to each. The MainViewModel is divided into three. One which take care of customer viewing, one which take care of new orders and the menu and one which take care of historical orders attached to the singular customer.
        /// The first two uses the same constructor and the last has its own contructor since we need to identify the specific customer that needs to be shown.
        /// In the three areas it sends of the information from the Model layer to the ViewModels to make sure that only the required information is shown in the view area. This also makes the search engine work as the ViewModel Observable Collection is constantly deleted and replenished from the static list in the lower layer.
        /// HistoryViewModel part also uses the same Items to display the customers orders. Using some items with only the properties of Dates and aligning them to the fully fledged orderlist but just showing the name instead.
        /// </summary>
        public MainViewModel() //The Constructor for both Customer and Order Related instances Might consider to split in two
        {
            customerList = new ObservableCollection<CustomerViewModel>();
            foreach (Customer customer in cr.Customers)
            {
                cvm = new CustomerViewModel(customer);
                CustomerList.Add(cvm);
            }
            menuList = new ObservableCollection<OrderViewModel>();
            foreach (Item item in or.MenuList)
            {
                ovm = new OrderViewModel(item);
                MenuList.Add(ovm);
            }
        }
        /////////////////////////////////////////////////////////////////
        //***This is taking care of the customer part of the Viewing***//
        /////////////////////////////////////////////////////////////////
        private CustomerRepository cr = new CustomerRepository();
        private ObservableCollection<CustomerViewModel> customerList;

        public ObservableCollection<CustomerViewModel> CustomerList
        {
            get { return customerList; }
            set { customerList = value; }
        }
        private CustomerViewModel selectedCustomer;
        private CustomerViewModel cvm;

        public CustomerViewModel SelectedCustomer
        {
            get { return selectedCustomer; }
            set { selectedCustomer = value; }
        }
        public void CreateCustomer(string newName, string newPhone, string newMail)
        {
            Customer newCustomer = cr.CreateCustomer(newName, newPhone, newMail);
            cvm = new CustomerViewModel(newCustomer);
            CustomerList.Add(cvm);
        }
        public void UpdateCustomer(string name, string phone, string mail, double points, double spend, CustomerViewModel customer)
        {
            cr.UpdateCustomer(name, phone, mail, points, spend, customer.Phone);
            cr.SaveList();
            AddSearchToList("");
        }
        public void DeleteCustomer(CustomerViewModel customer)
        {
            cr.DeleteCustomer(customer.Phone);
            cr.SaveList();
            AddSearchToList("");
        }
        public void AddSearchToList(string search)
        {
            if (search == "")
            {
                customerList.Clear();
                foreach (Customer customer in cr.Customers)
                {
                    cvm = new CustomerViewModel(customer);
                    CustomerList.Add(cvm);
                }
            }
            else
            {
                CustomerList.Clear();
                foreach (Customer customer in cr.Customers)
                {
                    string numberSearch = customer.TelephoneNumber.ToString();
                    if (numberSearch.Contains(search))
                    {
                        cvm = new CustomerViewModel(customer);
                        CustomerList.Add(cvm);
                    }
                }
            }
        }
        //////////////////////////////////////////////////
        //***This takes care of order related viewing***//
        //////////////////////////////////////////////////
        
        OrderRepository or = new OrderRepository();
        OrderViewModel ovm;
        private ObservableCollection<OrderViewModel> orderList = new ObservableCollection<OrderViewModel>();

        public ObservableCollection<OrderViewModel> OrderList
        {
            get { return orderList; }
            set { orderList = value; }
        }

        private ObservableCollection<OrderViewModel> menuList;
        public ObservableCollection<OrderViewModel> MenuList
        {
            get { return menuList; }
        }

        private OrderViewModel menuListSelectedItem;
        public OrderViewModel MenuListSelectedItem
        {
            get { return menuListSelectedItem; }
            set { menuListSelectedItem = value; }
        }

        private OrderViewModel orderListSelectedItem;

        public OrderViewModel OrderListSelectedItem
        {
            get { return orderListSelectedItem; }
            set { orderListSelectedItem = value; }
        }

        public OrderViewModel temporaryItem;

        public void AcceptOrder(string number)
        {
            foreach (OrderViewModel item in OrderList)
            {
                Pinsa tempItem = new Pinsa();
                tempItem.Name = item.Name;
                tempItem.Price = item.Price;
                or.Order.Add(tempItem);
            }
            int totalPrice = or.WriteToOrderHistory(SelectedCustomer.Phone.ToString());
            AddLPFromOrder(SelectedCustomer.Phone, totalPrice);
        }
        public void AcceptOrderWithBonus(string number)
        {
            foreach (OrderViewModel item in OrderList)
            {
                Pinsa tempItem = new Pinsa();
                tempItem.Name = item.Name;
                tempItem.Price = item.Price;
                or.Order.Add(tempItem);
            }
            (int totalPriceWithBonus, double loyaltyPointsReturned) = or.WriteToOrderHistoryWithBonus(
                SelectedCustomer.Phone.ToString(),SelectedCustomer.LoyaltyPoints);
            AddLPFromOrder(SelectedCustomer.Phone, totalPriceWithBonus, loyaltyPointsReturned); 
        }

        public void AddLPFromOrder(int phone, int totalPrice, double loyaltyPoints)
        {
            double newPoints = totalPrice / 10;
            loyaltyPoints += newPoints;

            cr.UpdateCustomer(phone, loyaltyPoints);
            cr.SaveList();
        }

        public void AddLPFromOrder(int phone, int totalPrice)
        {
            double newPoints = totalPrice / 10;

            cr.UpdateCustomer(phone, newPoints);
            cr.SaveList();
        }

        public void AddToOrderList(OrderViewModel selectedItem)
        {
            OrderViewModel newOrderViewModel = new OrderViewModel(selectedItem);
            OrderList.Add(newOrderViewModel);
        }
        
        public void RemoveFromOrderList(OrderViewModel selectedItem)
        {
            OrderList.Remove(selectedItem);
        }
        //////////////////////////////////////////////////
        //***This takes care of History related viewing***//
        //////////////////////////////////////////////////

        private ObservableCollection<HistoryViewModel> dateList = new ObservableCollection<HistoryViewModel>();
        
        public ObservableCollection<HistoryViewModel> DateList
        {
            get { return dateList; }
            set { dateList = value; }
        }
        private ObservableCollection<HistoryViewModel> nameList = new ObservableCollection<HistoryViewModel>();

        public ObservableCollection<HistoryViewModel> NameList
        {
            get { return nameList; }
            set { nameList = value; }
        }
        private HistoryViewModel selectedDate;

        public HistoryViewModel SelectedDate
        {
            get { return selectedDate; }
            set { selectedDate = value; }
        }

        HistoryViewModel hvm;
        public MainViewModel(string phone)
        {
            or.HistoryInitiator(phone);
            foreach (Item date in or.Dates)
            {
                hvm = new HistoryViewModel(date);
                DateList.Add(hvm);
            }
        }

        public void ShowChosenDate()
        {
            if (SelectedDate != null)
            {
                NameList.Clear();

                Pinsa pricePinsa = new Pinsa() { Name = "Total Price: " + SelectedDate.Price.ToString() }; //Total Price is made like a Pinsa so it can be shown on the list together with the other "Real" pinsas
                hvm = new HistoryViewModel(pricePinsa);
                NameList.Add(hvm);

                foreach (Pinsa pinsa in or.Order)
                {
                    if (SelectedDate.Date == pinsa.Date)
                    {
                    hvm = new HistoryViewModel(pinsa);
                    NameList.Add(hvm);
                    }
                }
            }
        }

    }
}
