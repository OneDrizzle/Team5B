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
    /// This is a Generic Confirmation Window to use if you need the user to confirm anything.
    /// Send custom string with yes/no question.
    /// </summary>
    public partial class WConfirmation : Window
    {
        public WConfirmation(string title)
        {
            InitializeComponent();
            ConfirmationTextBox.Text = title;
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
