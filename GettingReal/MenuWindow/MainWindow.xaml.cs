using GettingReal.ViewModels;
using System.Windows;

namespace MenuWindow
{
    public partial class MainWindow : Window
    {
        MainViewModel mvm;

        public MainWindow()
        {
            this.mvm = new MainViewModel();
            InitializeComponent();
        }

        public MainWindow(MainViewModel mvm)
        {
            this.mvm = mvm;
            InitializeComponent();
        }


        private void btn_boss_Click(object sender, RoutedEventArgs e)
        {

            ProjectChefWindow chefWindow = new ProjectChefWindow(mvm);
            chefWindow.Show();
            this.Close();
        }

        private void btn_tech_Click(object sender, RoutedEventArgs e)
        {
            TeknikkerWindow tech = new TeknikkerWindow(mvm);
            tech.Show();
            this.Close();
        }
    }
}
