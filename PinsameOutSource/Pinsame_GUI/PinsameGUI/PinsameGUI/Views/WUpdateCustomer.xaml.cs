using PinsameGUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PinsameGUI
{
    /// <summary>
    /// Is send the old information from the mainWindow. Then new information is saved in properties that can be accessed by the mainwindow. Like create customer the new information is protected from errors.
    /// </summary>
    public partial class WUpdateCustomer : Window
    {
        public string UpdatedName { get; set; }
        public string UpdatedPhone { get; set; }
        public string UpdatedMail { get; set; }
        public string UpdatedLoyaltyPoints { get; set; }

        public WUpdateCustomer(CustomerViewModel customer) //I think we should be able to delete orders attached to customer later. This should update Point and cost.
        {
            InitializeComponent();
            OldName.Text = customer.Name;
            OldNumber.Text = customer.Phone.ToString();
            OldMail.Text = customer.Mail;
            OldLoyaltyPoints.Text = customer.LoyaltyPoints.ToString();

            NewName.Text = customer.Name;
            NewPhone.Text = customer.Phone.ToString();
            NewMail.Text = customer.Mail;
            NewLoyaltyPoints.Text = customer.LoyaltyPoints.ToString();

            //Display List of Orders attached to customer
        }

        //Should create method to search orders and button to delete order from the list
        private void UpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (NewName.Text != "")
            {
                UpdatedName = NewName.Text;
            }
            else
            {
                UpdatedName = OldName.Text;
            }

            if (NewLoyaltyPoints.Text != "")
            {
                UpdatedLoyaltyPoints = NewLoyaltyPoints.Text;
            }
            else
            {
                UpdatedLoyaltyPoints = OldLoyaltyPoints.Text;
            }

            if (NewPhone.Text != "")
            {
                UpdatedPhone = NewPhone.Text;
            }
            else
            {
                UpdatedPhone = OldNumber.Text;
            }

            if (NewMail.Text != "")
            {
                UpdatedMail = NewMail.Text;
            }

            else
            {
                UpdatedMail = OldMail.Text;
            }

            DialogResult = true;
            Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public new void PreviewTextInput(object sender, TextCompositionEventArgs e)// Checks if gets a numeric value and not a string. 
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void NewMail_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            bool result = ValidatorExtensions.IsValidEmailAddress(NewMail.Text);

            if (!result)
            {
                MessageBox.Show("Undersøg venligst om den indtastede e-mail er indtastet korrekt.\n\nEn e-mail er ikke et krav for oprettelse af ny kunde.");
            }
        }

        private void customerRequirements()
        {
            UpdateCustomer.IsEnabled = false;

            if (NewPhone.Text.Length == 8 && NewName.Text.Length >= 1)
            {
                UpdateCustomer.IsEnabled = true;
            }
        }

        private void NewPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            customerRequirements();
        }

        private void NewName_TextChanged(object sender, TextChangedEventArgs e)
        {
            customerRequirements();
        }

        private void NewLoyaltyPoints_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
