using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TusindfrydWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<FlowerSort> flowerSorts;
        public MainWindow()
        {
            InitializeComponent();
            flowerSorts = new List<FlowerSort>();

        }

        private void Btn_Add_flowersort_Click(object sender, RoutedEventArgs e)
        {          
            CreateFlowerSortDialog flowerSortDialog = new CreateFlowerSortDialog();
            
            if ((bool)flowerSortDialog.ShowDialog())
            {
                flowerSorts.Add(flowerSortDialog.flower);
                StringBuilder sb = new StringBuilder();
                foreach (FlowerSort fs in flowerSorts)
                {
                    sb.AppendLine($"Navn: {fs.name}, Produktionstid: {fs.ProductionTime}, Halveringstid: {fs.HalfLifeTime}, Størrelse: {fs.size}");
                }
                Tb_Flowersort.Text = sb.ToString();
            }

            //switch (flowerSortDialog.DialogResult)
            //{
            //    case true:
            //        FlowerSort flower = new FlowerSort();
            //        flowerSorts.Add(flower);
            //        flower.name = flowerSortDialog.Tbx_Name.Text;
            //        flower.PicturePath = flowerSortDialog.Tbx_Img.Text;
            //        flower.HalfLifeTime = int.Parse(flowerSortDialog.Tbx_HalfTime.Text);
            //        flower.ProductionTime = int.Parse(flowerSortDialog.Tbx_ProductionTime.Text);
            //        flower.size = int.Parse(flowerSortDialog.Tbx_Size.Text);
            //        ; break;

            //    default:
            //        break;
            //}
        }

        private void Tb_Flowersort_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
