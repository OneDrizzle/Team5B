using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
            // er en tilbage knap

            window.Show();

            this.Close();
        }
        string JustFileName;
        string sourcePath;
        string OrdreNumber;
        private void btn_FindAgregateInfoFile_Click(object sender, RoutedEventArgs e)
        {
            // Åbner en Dialogbox hvor man kan finde et dokument
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.FileName = "";
            openFileDialog.DefaultExt = ".pdf";
            openFileDialog.Filter = "Pdf Filer|*.pdf";

            Nullable<bool> result = openFileDialog.ShowDialog();

            if (result == true)
            {
                //Gemmer Fil navnet ned til JustFileName og viser den ude i Gui'en 
                FileInfo fi = new FileInfo(openFileDialog.FileName);
                JustFileName = fi.Name;
                sourcePath = openFileDialog.FileName;
                GetInfoSheet.Text = JustFileName;

            }
        }

        private void btn_saveNewAgregat_Click_(object sender, RoutedEventArgs e)
        {
            string JustThisFileName = JustFileName;
            //Cpoy file to userdefined folder

            string fileName = OrdreNumber + JustThisFileName;
            string targetPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = ("\\GettingReal\\Aggregates");
            string filelocation = System.IO.Path.Combine(targetPath, path);

            string sourceFile = sourcePath;
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }

            File.Copy(sourceFile, destFile);

            window.Show();
            this.Close();
        }

        private void GetOrderNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            OrdreNumber = GetOrderNumber.Text + "_";
        }
    }
}
