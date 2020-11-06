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
    /// Interaction logic for ProjectChefWindow.xaml
    /// </summary>
    public partial class ProjectChefWindow : Window
    {
        public ProjectChefWindow()
        {
            InitializeComponent();
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();

            this.Close();
        }

        private void btn_CreateAgregat_Click(object sender, RoutedEventArgs e)
        {
            CreateAgregatWindow agregatWindow = new CreateAgregatWindow();

            agregatWindow.Show();

            this.Close();
        }
    }
}
