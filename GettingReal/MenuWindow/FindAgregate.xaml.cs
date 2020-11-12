using GettingReal;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;

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

        /*private void btn_SearchorAggregate_Click(object sender, RoutedEventArgs e)
        {
            //DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Bruger\Documents\GitHub\Team-5B\GettingReal\GettingReal\Aggregates");
            //dir.GetFiles("*.*", SearchOption.AllDirectories);
        }*/



        private void GetOrderNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FindOrderNumber.Text.Length != 6)
            {
                btn_OpenAggregateFile.IsEnabled = false;
            }

            else if (FindOrderNumber.Text.Length == 6)
            {
                btn_OpenAggregateFile.IsEnabled = true;


            }

        }

        private void btn_OpenAggregateFile_Click(object sender, RoutedEventArgs e)
        {
            string SelectedOrderNumber = FindOrderNumber.Text;
            //VentilationAggregateRepository aggregateRepo = new VentilationAggregateRepository();
            
            //VentilationAggregate aggregate = aggregateRepo.GetVentilationAggregate(SelectedOrderNumber);

            string targetPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = @"GettingReal\GettingReal\Aggregates\";

            int indexOfPath = targetPath.IndexOf("GettingReal");
            if (indexOfPath >= 0)
                targetPath = targetPath.Remove(indexOfPath);
            string destFile = System.IO.Path.Combine(targetPath, path);

            DirectoryInfo dir = new DirectoryInfo(destFile);
            FileInfo[] files = dir.GetFiles(SelectedOrderNumber + "*", SearchOption.TopDirectoryOnly);
            foreach (FileInfo fileFound in files)
            {
                string NewPath = Path.Combine(fileFound.Name, destFile + System.IO.Path.GetFileName(fileFound.Name));

                Process.Start(new ProcessStartInfo(NewPath) { UseShellExecute = true });
            }

            ProjectChefWindow main = new ProjectChefWindow();
            main.Show();
            this.Close();
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            ProjectChefWindow main = new ProjectChefWindow();
            main.Show();
            this.Close();
        }
    }
}
