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
using GettingReal.ViewModels;

namespace MenuWindow
{
    /// <summary>
    /// Interaction logic for ProjectChefWindow.xaml
    /// </summary>
    public partial class ProjectChefWindow : Window
    {
        MainViewModel mvm;
        public ProjectChefWindow(MainViewModel mvm)
        {
            InitializeComponent();
            this.mvm = mvm;
            DataContext = mvm;
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow(mvm);
            main.Show();

            this.Close();
        }

        private void btn_CreateAggregate_Click(object sender, RoutedEventArgs e)
        {
            CreateAgregatWindow aggregateWindow = new CreateAgregatWindow(mvm);

            aggregateWindow.Show();

            this.Close();
        }

        private void btn_FindAggregate_Click(object sender, RoutedEventArgs e)
        {
            FindAgregate AggregateWindow = new FindAgregate(mvm);
            AggregateWindow.Show();
            this.Close();
        }
    }
}
