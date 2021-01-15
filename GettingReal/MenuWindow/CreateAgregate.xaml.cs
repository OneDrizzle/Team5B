using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using GettingReal;
using GettingReal.ViewModels;

namespace MenuWindow
{

    public partial class CreateAgregatWindow : Window
    {
        MainViewModel mvm;
        ProjectChefWindow projectBossWindow;
        

        public CreateAgregatWindow(MainViewModel mvm)
        {
            InitializeComponent();
            this.mvm = mvm;          
            DataContext = mvm;
            mvm.NewCustomerRequested += NewCustomerRequestedHandler;
            mvm.ItemsChanged += ItemsChangedHandler;
        }

        private void ItemsChangedHandler(object sender, ItemSelectionEventArgs e)
        {
            if (sender is VMCustomer)
            {
                GetCustomer.SelectedItem = e.SelectedItem;
            }
            else if (sender is VMBuilding)
            {
                GetBuilding.SelectedItem = e.SelectedItem;
            }
        }

        private CustomerEventArgs NewCustomerRequestedHandler(object sender, CustomerEventArgs args)
        {
            args = new CustomerEventArgs();
            CreateCustomer createCustomerWindow = new CreateCustomer();

            if ((bool)createCustomerWindow.ShowDialog())
            {
                args.Name = createCustomerWindow.tb_CustomerName.Text;
                args.Company= createCustomerWindow.tb_CompanyName.Text;
                return args;
            }
            
            return null;
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            projectBossWindow = new ProjectChefWindow(mvm);
            projectBossWindow.Show();
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
            openFileDialog.Filter = "";

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
            
            Utility.SaveFile(sourcePath, orderNumber, justFileName);
            mvm.AddVentilationAggregate(justFileName.Substring(0, justFileName.IndexOf(".")-1));
            projectBossWindow = new ProjectChefWindow(mvm);
            projectBossWindow.Show();
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

                (int c, string fn) = Utility.NumberOfFiles(orderNumber);
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
