using System;
using System.Collections.Generic;
using System.Text;
using WPFAndMVVM2.Models;

namespace WPFAndMVVM2.ViewModels
{
    public class PersonViewModel
    {
        private Person person;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }

        public PersonViewModel(Person person)
        {
            this.person = person;
            FirstName = person.FirstName;
            LastName = person.LastName;
            Age = person.Age;
            Phone = person.Phone;
        }

        public int GetID()
        {
            return person.Id;
        }
    }
}
