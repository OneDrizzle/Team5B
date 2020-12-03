using PinsameGUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PinsameGUI
{
    /// <summary>
    /// Gets the base information about the customer from the window. The listbox is in DataContext to the MainViewModel. Together they give a complete view of the customers information. There is no ability to change anything here. It is only meant to show the full information about the customer as a helping tool to the user.
    /// </summary>
    public partial class DisplayCustomer : Window
    {
        //jacob's displaycustomer.
        MainViewModel mvm;
        public DisplayCustomer(CustomerViewModel customer)
        {
            InitializeComponent();
            DisplayName.Text = customer.Name;
            DisplayTelephone.Text = customer.Phone.ToString();
            DisplayEmail.Text = customer.Mail;
            DisplayPoints.Text = customer.LoyaltyPoints.ToString();
            DisplayCost.Text = customer.TotalSpend.ToString();
            mvm = new MainViewModel(customer.Phone.ToString());
            DataContext = mvm;
        }

        //Retrun to main buttom
        private void bnReturn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ListDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mvm.ShowChosenDate();
        }
    }
}
