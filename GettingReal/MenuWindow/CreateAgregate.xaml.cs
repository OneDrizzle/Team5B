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

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            ProjectChefWindow window = new ProjectChefWindow();

            window.Show();

            this.Close();
        }
        private void btn_FindAgregateInfoFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.FileName = "";
            openFileDialog.DefaultExt = ".pdf";
            openFileDialog.Filter = "Pdf Filer|*.pdf";

            Nullable<bool> result = openFileDialog.ShowDialog();

            if (result == true)
            {   
                FileInfo fi = new FileInfo(openFileDialog.FileName);
                string JustFileName = fi.Name;
                GetInfoSheet.Text = JustFileName;
            }
            
        }
    }
}
