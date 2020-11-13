using GettingReal;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace MenuWindow
{

    public partial class CreateAgregatWindow : Window
    {

        Controller ctr = new Controller();
        ProjectChefWindow window = new ProjectChefWindow();
        public CreateAgregatWindow()
        {
            InitializeComponent();
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            // Back button

            window.Show();

            this.Close();
        }
        string JustFileName;
        string sourcePath;
        string OrderNumber;
        private void btn_FindAgregateInfoFile_Click(object sender, RoutedEventArgs e)
        {
            // Opens a dialog box that allows user to find and choose a file from their pc
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.FileName = "";
            openFileDialog.DefaultExt = ".pdf";
            //sets the filter to show pdf files
            openFileDialog.Filter = "Pdf Files|*.pdf";

            Nullable<bool> result = openFileDialog.ShowDialog();

            if (result == true)
            {
                // saves selected file to "JustFileName" and shows it in the GUI

                FileInfo fi = new FileInfo(openFileDialog.FileName);
                JustFileName = fi.Name;
                GetInfoSheet.Text = JustFileName;
                //saves file path to scourcepath
                sourcePath = openFileDialog.FileName;
            }
        }

        private void btn_saveNewAgregat_Click_(object sender, RoutedEventArgs e)
        {
            //Cpoy file to userdefined folder

            string targetPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

            string path = @"GettingReal\GettingReal\Aggregates\";
            //looks for the first instance of "GettingReal" in the path.
            //Removes "GettingReal" and inputs the path so the path is the same as "TargetPath + path"
            int indexOfPath = targetPath.IndexOf("GettingReal");
            if (indexOfPath >= 0)
                targetPath = targetPath.Remove(indexOfPath);
            //Combines the two paths togehter and sets \\ in Automaticly so it's a full and useable path
            string destFile = System.IO.Path.Combine(targetPath, path);

            // if there is no Directory named Aggregates it creates one
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }

            //the next code takes the file that need's to be copied and copies it into the "DestinationDirectory" folder
            //and adds the OrderNumber at the end so we can search for it later
            File.Copy(sourcePath, destFile + System.IO.Path.GetFileName(sourcePath));
            string Rename = OrderNumber + JustFileName;


            string ScourceFile = Path.Combine(sourcePath, destFile + System.IO.Path.GetFileName(sourcePath));
            System.IO.FileInfo fi = new System.IO.FileInfo(ScourceFile);
            string NewPath = "";
            if (fi.Exists)
            {
                NewPath = Path.Combine(Rename, destFile + System.IO.Path.GetFileName(Rename));
                fi.MoveTo(NewPath);
            }


            //here it filters out everything after the first 6 Char's
            string PureOrdereNumber = Rename.Substring(0, 6);
            ctr.AddVentilationAggregate(PureOrdereNumber);

            window.Show();
            this.Close();
        }

        private void GetOrderNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (GetOrderNumber.Text.Length != 6)
            {
                btn_saveNewAgregat.IsEnabled = false;
                lbl_Error.Content = ("");
            }

            else if (GetOrderNumber.Text.Length == 6)
            {
                OrderNumber = GetOrderNumber.Text;

                string targetPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string path = @"GettingReal\GettingReal\Aggregates\";

                int indexOfPath = targetPath.IndexOf("GettingReal");
                int count = 0;
                if (indexOfPath >= 0)
                {

                    targetPath = targetPath.Remove(indexOfPath);
                    string destFile = System.IO.Path.Combine(targetPath, path);

                    DirectoryInfo dir = new DirectoryInfo(destFile);
                    FileInfo[] files = dir.GetFiles(OrderNumber + "*", SearchOption.TopDirectoryOnly);
                    foreach (FileInfo fileFound in files)
                    {
                        count++;
                        btn_saveNewAgregat.IsEnabled = false;
                        lbl_Error.Content = ("Dette ordrenummer eksisterer allerede");
                    }
                }
                if (count == 0)
                {
                    btn_saveNewAgregat.IsEnabled = true;
                    OrderNumber = GetOrderNumber.Text + "_";



                }
            }
        }
    }
}
