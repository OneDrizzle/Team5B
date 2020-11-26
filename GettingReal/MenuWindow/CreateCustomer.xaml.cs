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
        MainViewModel mvm;
        public CreateCustomer(MainViewModel mvm)
        {
            InitializeComponent();
            this.mvm = mvm;
            DataContext = mvm;
        }


        private void btn_AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            mvm.AddCustomer();
            this.Close();

        }
        private void btn_back_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
