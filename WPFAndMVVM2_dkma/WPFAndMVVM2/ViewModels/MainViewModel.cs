using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Controls;
using WPFAndMVVM2.Models;

namespace WPFAndMVVM2.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private PersonRepository personRepo = new PersonRepository();

        public ObservableCollection<PersonViewModel> PersonsVM { get; set; }

        private PersonViewModel selectedPersonViewModel;
        public PersonViewModel SelectedPersonViewModel 
        {
            get { return selectedPersonViewModel; }
            set { selectedPersonViewModel = value; OnPropertyChanged("SelectedPersonViewModel");} 
        }

        // Implement the rest of this MainViewModel class below to 
        // establish the foundation for data binding !

        public MainViewModel()
        {
            PersonsVM = new ObservableCollection<PersonViewModel>();

            foreach (Person person in personRepo.GetAll())
            {
                PersonsVM.Add(new PersonViewModel(person));
            }
        }

        public void AddDefaultPerson()
        {
            PersonsVM.Add(new PersonViewModel(personRepo.Add("Specify FirstName", "Specify LastName", 0, "Specify Phone")));
            SelectedPersonViewModel = PersonsVM[PersonsVM.Count-1];            
        }

        public void DeleteSelectedPerson()
        {
            //int place = PersonsVM.IndexOf(SelectedPersonViewModel) -1;
           personRepo.Remove(SelectedPersonViewModel.GetID());
            PersonsVM.Remove(SelectedPersonViewModel);
            //SelectedPersonViewModel = PersonsVM[place];            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }   


    }
}
