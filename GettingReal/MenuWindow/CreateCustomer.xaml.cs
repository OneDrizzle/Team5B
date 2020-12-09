using System.Windows;
using System.Windows.Controls;
using GettingReal;
using GettingReal.ViewModels;


namespace MenuWindow
{
    /// <summary>
    /// Interaction logic for CreateCustomer.xaml
    /// </summary>
    public partial class CreateCustomer : Window
    {
        public CreateCustomer()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void btn_AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        private void btn_back_click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
