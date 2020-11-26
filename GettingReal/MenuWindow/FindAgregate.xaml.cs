using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using GettingReal;
using GettingReal.Models;
using GettingReal.ViewModels;

namespace MenuWindow
{
    /// <summary>
    /// Interaction logic for FindAgregate.xaml
    /// </summary>
    public partial class FindAgregate : Window
    {
        MainViewModel mvm;
        public FindAgregate(MainViewModel mvm)
        {
            InitializeComponent();
            this.mvm = mvm;
        }

        int count = 0;
        string filename = "";
        private void GetOrderNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FindOrderNumber.Text.Length != 6)
            {
                btn_OpenAggregateFile.IsEnabled = false;
                lbl_Error.Content = ("");
            }

            else if (FindOrderNumber.Text.Length == 6)
            {
                string SelectedOrderNumber = FindOrderNumber.Text;

                (int c, string fn) = Utility.NumberOfFiles(SelectedOrderNumber);
                count = c;
                filename = fn;

                if (count > 0)
                {
                    btn_OpenAggregateFile.IsEnabled = true;
                }
                else
                {
                    lbl_Error.Content = ("Dette ordrenummer eksisterer ikke");
                }

            }

        }

        private void btn_OpenAggregateFile_Click(object sender, RoutedEventArgs e)
        {
            string SelectedOrderNumber = FindOrderNumber.Text;
            //VentilationAggregateRepository aggregateRepo = new VentilationAggregateRepository();

            //VentilationAggregate aggregate = aggregateRepo.GetVentilationAggregate(SelectedOrderNumber);

            (string df, string tp) = Utility.FindFile();
            string destFile = df;
            string NewPath = Path.Combine(filename, destFile + System.IO.Path.GetFileName(filename));
            Process.Start(new ProcessStartInfo(NewPath) { UseShellExecute = true });

            ProjectChefWindow ManagerWindow = new ProjectChefWindow(mvm);
            ManagerWindow.Show();
            this.Close();
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            ProjectChefWindow ManagerWindow = new ProjectChefWindow(mvm);
            ManagerWindow.Show();
            this.Close();
            
        }
    }
}
