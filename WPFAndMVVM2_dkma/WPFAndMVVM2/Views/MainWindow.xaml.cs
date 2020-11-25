using System.Windows;
using WPFAndMVVM2.ViewModels;

namespace WPFAndMVVM2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel mvm = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = mvm;
        }

        private void btnNewPerson_Click(object sender, RoutedEventArgs e)
        {
            mvm.AddDefaultPerson();
            listBox.ScrollIntoView(mvm.SelectedPersonViewModel);
        }

        private void btnDeletePerson_Click(object sender, RoutedEventArgs e)
        {
            mvm.DeleteSelectedPerson();
            listBox.ScrollIntoView(mvm.SelectedPersonViewModel);
        }
    }
}
