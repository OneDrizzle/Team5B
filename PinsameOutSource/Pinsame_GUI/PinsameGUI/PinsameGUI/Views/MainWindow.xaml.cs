using PinsameGUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using PinsameGUI.ViewModels;

namespace PinsameGUI
{
    /// <summary>
    /// This is the hub of the program. It communicates to our MainViewModel with the information that is sent to it via the Dialogs of CreateCustomer, UpdateCustomer and DeleteCustomer.
    /// Incorperated is the searchEngine linked trough the MainViewModel to the deeper layers of the program.
    /// In the MainWindow itself the only binds are the ones to the listbox using the MainViewModel as the DataContext.
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel mvm = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = mvm;
        }
    


       private void SearchField_TextChanged(object sender, TextChangedEventArgs e)
        {
            mvm.AddSearchToList(SearchField.Text);
            SearchRequirements();
        }

        private void Create_Customer_Click(object sender, RoutedEventArgs e)
        {
            WCreateCustomer wcc = new WCreateCustomer();
            if (wcc.ShowDialog() == true)
            {
                mvm.CreateCustomer(wcc.Name, wcc.Number, wcc.Mail);
            }
        }

        private void Display_Customer_Click(object sender, RoutedEventArgs e)
        {
            
            DisplayCustomer dsc = new DisplayCustomer(mvm.SelectedCustomer);
            dsc.Show();
        }

        private void Update_Customer_Click(object sender, RoutedEventArgs e)
        {
            WUpdateCustomer wuc = new WUpdateCustomer(mvm.SelectedCustomer);
            if (wuc.ShowDialog() == true)
            {
                mvm.UpdateCustomer(wuc.UpdatedName, wuc.UpdatedPhone, wuc.UpdatedMail, double.Parse(wuc.UpdatedLoyaltyPoints), mvm.SelectedCustomer.TotalSpend, mvm.SelectedCustomer);
                Display_Customer.IsEnabled = false;
                Update_Customer.IsEnabled = false;
                Delete_Customer.IsEnabled = false;
                ChooseCustomer.IsEnabled = false;
            }
        }

        private void Delete_Customer_Click(object sender, RoutedEventArgs e)
        {
            WConfirmation wc = new WConfirmation($"Are you sure you want to delete {mvm.SelectedCustomer.Name}?");

            if (wc.ShowDialog() == true)
            {
                mvm.DeleteCustomer(mvm.SelectedCustomer);
                Display_Customer.IsEnabled = false;
                Update_Customer.IsEnabled = false;
                Delete_Customer.IsEnabled = false;
                ChooseCustomer.IsEnabled = false;
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            WConfirmation wc = new WConfirmation("Are you sure you want to exit?");

            if (wc.ShowDialog() == true)
            {
                Close();
            }
        }

        public new void PreviewTextInput(object sender, TextCompositionEventArgs e) // Checks if SearchField gets a numeric value and not a string. 
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ChooseCustomer_Click(object sender, RoutedEventArgs e) //This starts the order creation after customer is selected in the listbox
        {
            DisplayMenu dm = new DisplayMenu(mvm);
            if (dm.ShowDialog() == true)
            {
                MessageBox.Show("You have successfully created an order");
            }
        }

        private void CustomerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Display_Customer.IsEnabled = true;
            Update_Customer.IsEnabled = true;
            Delete_Customer.IsEnabled = true;
            ChooseCustomer.IsEnabled = true;
        }

        private void SearchRequirements()
        {
            if (SearchField.Text.Length < 8)
            {
                ChooseCustomer.IsEnabled = false;
                Display_Customer.IsEnabled = false;
                Update_Customer.IsEnabled = false;
                Delete_Customer.IsEnabled = false;
            }
        }

        //Double click on a costumer to open a new order for the selected costumer //Laur
        private void CustomerList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {            
            DisplayMenu dm = new DisplayMenu(mvm);
            if (dm.ShowDialog() == true)
            {
                MessageBox.Show("You have successfully created an order");
            }
        }
    }
}
