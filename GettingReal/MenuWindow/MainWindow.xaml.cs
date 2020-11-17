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
using GettingReal.ViewModels;

namespace MenuWindow
{
    public partial class MainWindow : Window
    {
        MainViewModel mvm;

        public MainWindow()
        {
            InitializeComponent();
            mvm = new MainViewModel();
        }

        private void btn_boss_Click(object sender, RoutedEventArgs e)
        {

            ProjectChefWindow chefWindow = new ProjectChefWindow();
            chefWindow.Show();

            this.Close();
        }

        private void btn_tech_Click(object sender, RoutedEventArgs e)
        {
            TeknikkerWindow tech = new TeknikkerWindow();
            tech.Show();

            this.Close();
        }
    }
}
