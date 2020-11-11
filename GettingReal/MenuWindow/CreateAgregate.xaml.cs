using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace MenuWindow
{
    /// <summary>
    /// Interaction logic for CreateAgregatWindow.xaml
    /// </summary>
    public partial class CreateAgregatWindow : Window
    {
        public CreateAgregatWindow()
        {
            InitializeComponent();
        }

        ProjectChefWindow window = new ProjectChefWindow();
        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            // Back button

            window.Show();

            this.Close();
        }
        string JustFileName;
        string sourcePath;
        string OrdreNumber;
        private void btn_FindAgregateInfoFile_Click(object sender, RoutedEventArgs e)
        {
            // OPens a dialog box that allows user to find and choose a file from their pc
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.FileName = "";
            openFileDialog.DefaultExt = ".pdf";
            openFileDialog.Filter = "Pdf Files|*.pdf";

            Nullable<bool> result = openFileDialog.ShowDialog();

            if (result == true)
            {
                //Gemmer Fil navnet ned til JustFileName og viser den ude i Gui'en 
                
                FileInfo fi = new FileInfo(openFileDialog.FileName);
                JustFileName = fi.Name;
                GetInfoSheet.Text = JustFileName;
                sourcePath = openFileDialog.FileName;

            }
        }

        private void btn_saveNewAgregat_Click_(object sender, RoutedEventArgs e)
        {
            //Cpoy file to userdefined folder

            string targetPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = @"GettingReal\GettingReal\Aggregates\";
            int indexOfPath = targetPath.IndexOf("GettingReal");
            if (indexOfPath >= 0)
                targetPath = targetPath.Remove(indexOfPath);
            string destFile = System.IO.Path.Combine(targetPath, path);

            string fileToCopy = sourcePath;
            string destinationDirectory = destFile;


            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }

            File.Copy(fileToCopy, destinationDirectory + System.IO.Path.GetFileName(fileToCopy + OrdreNumber));
            string input = fileToCopy + OrdreNumber;
            int index = input.LastIndexOf(".");
            if (index > 0)
                input = input.Substring(0, index);
            string PureOrdreNumber = input.Substring(input.IndexOf('_') + 1);

            window.Show();
            this.Close();

        }

        private void GetOrderNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            OrdreNumber = "_" + GetOrderNumber.Text + ".pdf";
        }
    }
}
