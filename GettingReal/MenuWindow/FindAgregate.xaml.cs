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
        Utility utility = new Utility();
        public FindAgregate()
        {
            InitializeComponent();
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
                btn_OpenAggregateFile.IsEnabled = true;

                string SelectedOrderNumber = FindOrderNumber.Text;

                (int c, string fn) = utility.NumberOfFiles(SelectedOrderNumber);
                count = c;
                filename = fn;
                //
                //string targetPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                //string path = @"GettingReal\GettingReal\Aggregates\";

                //int indexOfPath = targetPath.IndexOf("GettingReal");
                //if (indexOfPath >= 0)
                //    targetPath = targetPath.Remove(indexOfPath);
                //string destFile = System.IO.Path.Combine(targetPath, path);

                //DirectoryInfo dir = new DirectoryInfo(destFile);
                //FileInfo[] files = dir.GetFiles(SelectedOrderNumber + "*", SearchOption.TopDirectoryOnly);

                //foreach (FileInfo fileFound in files)
                //{
                //    filename = fileFound.Name;
                //    count++;
                //}
                ////
                if (count > 0)
                {
                    btn_OpenAggregateFile.IsEnabled = true;
                }
                else
                {
                    btn_OpenAggregateFile.IsEnabled = false;
                    lbl_Error.Content = ("Dette ordrenummer eksisterer ikke");
                }

            }

        }

        private void btn_OpenAggregateFile_Click(object sender, RoutedEventArgs e)
        {
            string SelectedOrderNumber = FindOrderNumber.Text;
            //VentilationAggregateRepository aggregateRepo = new VentilationAggregateRepository();

            //VentilationAggregate aggregate = aggregateRepo.GetVentilationAggregate(SelectedOrderNumber);

            string destFile = utility.FindFile(SelectedOrderNumber);
            //string targetPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //string path = @"GettingReal\GettingReal\Aggregates\";

            //int indexOfPath = targetPath.IndexOf("GettingReal");
            //if (indexOfPath >= 0)
            //    targetPath = targetPath.Remove(indexOfPath);
            //string destFile = System.IO.Path.Combine(targetPath, path);

            DirectoryInfo dir = new DirectoryInfo(destFile);
            FileInfo[] files = dir.GetFiles(SelectedOrderNumber + "*", SearchOption.TopDirectoryOnly);





            string NewPath = Path.Combine(filename, destFile + System.IO.Path.GetFileName(filename));
            Process.Start(new ProcessStartInfo(NewPath) { UseShellExecute = true });

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
