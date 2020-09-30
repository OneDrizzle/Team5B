using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using HYDACTesTMenu;

namespace HYDAC
{
    public class Employee
    {
        private string _name;
        private Mood _mood;
        private Guest[] _guests = new Guest[10];

        public enum Mood
        {
            Moodless,
            Sad,
            Neutral,
            Happy
        };

        public Employee(string name)
        {
            this._name = name;
        }

        public void AddGuest(string name, string phone, string mail)
        {
            _guests[(_guests.Length - (_guests.Length - 1))] = new Guest(name, phone, mail);
            // hent data fra controller i form af et array 
            // insert data into guest array 
            // find ud af hvordan i indsætter mood i array, i den rigtige rakke føgle 

            /*
            if (_guests.Length <= 0)
            {
                //her sørger jeg for at den altid starter med index tallet 0 i array'ed
                _guests[_guests.Length] = new Guest(name, phone, mail);
            }
            else
            {
                //her bruger jeg +1 til at den altid under oprettesen, så den insætter det nye gæst ind bagrest i array'ed
                _guests[_guests.Length + 1] = new Guest(name, phone, mail);

            }
            */
        }

        public void RemoveGuest(string name)
        {


            // her kigger vi efter et navn i de gælde objecter og sletter object vis navnet blev fundet i en af dem.
            for (int i = 0; i < _guests.Length; i++)
            {
                if (_guests[i].Name == name)
                {
                    _guests = _guests.Where(e => e != _guests[i]).ToArray();
                    break;
                }
            }
        }

        public void SetMood(Mood mood)
        {
            _mood = mood;
        }
        public string GetName()
        {
            return _name;
        }
    }

}
