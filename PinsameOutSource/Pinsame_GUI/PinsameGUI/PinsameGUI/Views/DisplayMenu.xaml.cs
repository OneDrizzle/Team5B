using PinsameGUI.Models;
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

namespace PinsameGUI.Views
{
    /// <summary>
    /// As this also includes ListBox this goes directly to the MainViewModel and uses that DataContext. It can save items from one listbox to the next using the commands of the buttons (Or remove them from the list) Order can be modified and is saved in a txt of its own trough the lower layers. To protect an ongoing order a confirmation is needed to leave the window if any item is placed in the order.
    /// </summary>
    public partial class DisplayMenu : Window
    {
        MainViewModel mvm;
        public DisplayMenu(MainViewModel mvm) //This could be a customer so you can see name and telephonenumber of the person you are making a order for
        {
            InitializeComponent();
            this.mvm = mvm;
            DataContext = mvm;
            CustomerNo.Content = mvm.SelectedCustomer.Phone;
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            mvm.AcceptOrder(CustomerNo.Content.ToString());
            DialogResult = true;
        }
        private void btnAcceptWithBonus_Click(object sender, RoutedEventArgs e)
        {
            mvm.AcceptOrderWithBonus(CustomerNo.Content.ToString());
            DialogResult = true;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (OrderList.Items.Count > 0)
            {
                WConfirmation wc = new WConfirmation("Are you sure you want to cancel the current order?");
                if (wc.ShowDialog() == true)
                {
                    DialogResult = false;
                }
            }
            else
                DialogResult = false;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (MenuList.SelectedIndex != -1)
                mvm.AddToOrderList(mvm.MenuListSelectedItem);
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            mvm.RemoveFromOrderList(mvm.OrderListSelectedItem);
            if (mvm.OrderList.Count > 0)
                OrderList.SelectedItem = mvm.OrderList[mvm.OrderList.Count - 1];
        }

        //Double click a menu item to add it to the menu //Laur
        private void MenuList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (MenuList.SelectedIndex != -1)
                mvm.AddToOrderList(mvm.MenuListSelectedItem);
        }

        //double click a order item to remove it from the order //Laur
        private void OrderList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            mvm.RemoveFromOrderList(mvm.OrderListSelectedItem);
            if (mvm.OrderList.Count > 0)
                OrderList.SelectedItem = mvm.OrderList[mvm.OrderList.Count - 1];
        }
    }
}
