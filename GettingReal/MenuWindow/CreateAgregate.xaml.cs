using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace MenuWindow
{

    public partial class CreateAgregatWindow : Window
    {
        Utility utility = new Utility();
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


        string justFileName;
        string sourcePath;
        string orderNumber;
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
                justFileName = fi.Name;
                GetInfoSheet.Text = justFileName;
                //saves file path to scourcepath
                sourcePath = openFileDialog.FileName;
            }
        }

        private void btn_saveNewAgregat_Click_(object sender, RoutedEventArgs e)
        {
            utility.SaveFile(sourcePath, orderNumber, justFileName);
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
                orderNumber = GetOrderNumber.Text;

                (int c, string fn) = utility.NumberOfFiles(orderNumber);
                int count = c;

                if (count > 0)
                {
                    btn_saveNewAgregat.IsEnabled = false;
                    lbl_Error.Content = ("Dette ordrenummer eksisterer allerede");
                }
                
                if (count == 0)
                {
                    btn_saveNewAgregat.IsEnabled = true;
                    orderNumber = GetOrderNumber.Text + "_";
                }



            }
        }
    }
}
