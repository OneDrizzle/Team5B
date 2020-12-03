using Accessibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Gives user the ability to input information about the customer. It is safeguarded so that a valid email is required and only number is allowed in the phone. It returns the values using properties that the main window can get.
    /// </summary>
    public partial class WCreateCustomer : Window
    {
        public WCreateCustomer()
        {
            InitializeComponent();
        }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Mail { get; set; }
        private void CreateCustomer_Click(object sender, RoutedEventArgs e)
        {            
            try
            {
                Name = NewName.Text;
                Number = NewNumber.Text;
                Mail = NewMail.Text;
                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kunde er ikke oprettet korrekt, tjek at alle informationer er korrekt indtastet. \n\n" + ex.Message, ".", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
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
            CreateCustomer.IsEnabled = false;

            if (NewNumber.Text.Length == 8 && NewName.Text.Length >= 1)
            {
                CreateCustomer.IsEnabled = true;
            }
        }

        public new void PreviewTextInput(object sender, TextCompositionEventArgs e)// Checks if gets a numeric value and not a string. 
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void NewNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            customerRequirements();
        }

        private void NewName_TextChanged(object sender, TextChangedEventArgs e)
        {
            customerRequirements();
        }


    }
}
