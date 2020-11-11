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

namespace MenuWindow
{
    /// <summary>
    /// Interaction logic for FindAgregate.xaml
    /// </summary>
    public partial class FindAgregate : Window
    {
        public FindAgregate()
        {
            InitializeComponent();
        }

        private void btn_SearchorAgregate_Click(object sender, RoutedEventArgs e)
        {
            //DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Bruger\Documents\GitHub\Team-5B\GettingReal\GettingReal\Aggregates");
            //dir.GetFiles("*.*", SearchOption.AllDirectories);
        }

            private void GetOrderNumber_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_saveNewAgregat_Click_(object sender, RoutedEventArgs e)
        {

        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
