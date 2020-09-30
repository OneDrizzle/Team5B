using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

namespace HYDAC
{
    public class Employee
    {
        private string name;
        private Mood mood;
        private Guest[] guests;
        private int antalGæster;

        public enum Mood
        {
            Moodless = 0,
            Happy = 1,
            Neutral = 2,
            Sad = 3
        }

        public Mood Humør { get; set; }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public int AntalGæster
        {
            get
            {
                return antalGæster;
            }
        }


        public Employee(string name)
        {
            guests = new Guest[20];
            this.name = name;
            antalGæster = 0;
        }
        public Employee(string name, int mood) //evt med Guest guest ?
        {
            guests = new Guest[20];
            this.name = name;
            this.Humør = (Mood)mood;
            antalGæster = 0;
        }

        public Guest[] Guests
        {
            get
            {
                return guests;
            }
            set
            {
                guests = value;
            }

        }

        public void RemoveGuest(string name)
        {
            // her kigger vi efter et navn i gæste objecter og sletter object vis navnet blev fundet i en af dem.
            for (int i = 0; i < guests.Length; i++)
            {
                if (guests[i].Name == name)
                {
                    guests = guests.Where(e => e != guests[i]).ToArray();

                    antalGæster--;
                    Array.Resize<Guest>(ref guests, 20);
                    break;
                }
            }

            //Fjerne gæsten fra txt filen
            Data.RemoveGuestFromTXT(name);
        }

        public void AddGuest(Guest guest, Employee employee)
        {
            guests[antalGæster] = guest;
            antalGæster++;

            Data.AddGuestToTXT(guest, employee);
        }



    }
}



