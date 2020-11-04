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
using System.Windows.Shapes;

namespace TusindfrydWPF
{
    /// <summary>
    /// Interaction logic for CreateFlowerSortDialog.xaml
    /// </summary>
    public partial class CreateFlowerSortDialog : Window
    {
        string[] arr = new string[5];
       public FlowerSort flower;
        public CreateFlowerSortDialog()
        {
            InitializeComponent();
            Btn_Accept.IsEnabled = false;
            flower = new FlowerSort();
        }

        private void Tbx_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
           arr[0] = Tbx_Name.Text;
            int fin=0;
            foreach (var item in arr)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    fin++;
                }
            }
            if (fin==5)
            {
                Btn_Accept.IsEnabled = true;
            }
        }


        private void Tbx_Img_TextChanged(object sender, TextChangedEventArgs e)
        {
            arr[1] = Tbx_Img.Text;
            int fin = 0;
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();

            try
            {
                Img_Flower.Source = new BitmapImage(new Uri(Tbx_Img.Text, UriKind.Relative));
                bitmap.UriSource = new Uri(@Tbx_Img.Text);
            }
            catch (Exception)
            {
                Img_Flower.Source = new BitmapImage(new Uri("/Images/Default.jpg", UriKind.Relative));
                bitmap.UriSource = new Uri(@Tbx_Img.Text);
            }
            finally
            {
            bitmap.EndInit();
            }

            foreach (var item in arr)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    fin++;
                }
            }
            if (fin == 5)
            {
                Btn_Accept.IsEnabled = true;
            }
        }

        private void Tbx_HalfTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            arr[2] = Tbx_HalfTime.Text;
            int fin = 0;
            foreach (var item in arr)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    fin++;
                }
            }
            if (fin == 5)
            {
                Btn_Accept.IsEnabled = true;
            }
        }

        private void Tbx_ProductionTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            arr[3] = Tbx_ProductionTime.Text;
            int fin = 0;
            foreach (var item in arr)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    fin++;
                }
            }
            if (fin == 5)
            {
                Btn_Accept.IsEnabled = true;
            }
        }

        private void Tbx_Size_TextChanged(object sender, TextChangedEventArgs e)
        {
            arr[4] = Tbx_Size.Text;
            int fin = 0;
            foreach (var item in arr)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    fin++;
                }
            }
            if (fin == 5)
            {
                Btn_Accept.IsEnabled = true;
            }
        }
        private void Btn_Accept_Click(object sender, RoutedEventArgs e)
        {
            flower.name = Tbx_Name.Text;
            flower.PicturePath = Tbx_Img.Text;
            flower.HalfLifeTime = int.Parse(Tbx_HalfTime.Text);
            flower.ProductionTime = int.Parse(Tbx_ProductionTime.Text);
            flower.size = int.Parse(Tbx_Size.Text);
            this.DialogResult = true;
        }
    }
}
