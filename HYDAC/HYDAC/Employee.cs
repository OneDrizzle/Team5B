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
        private int antalArrayGæster = 0;

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
            guests = new Guest[1];
            this.name = name;
            antalGæster = 0;
        }
        public Employee(string name, int mood) //evt med Guest guest ?
        {
            guests = new Guest[1];
            this.name = name;
            this.Humør = (Mood)mood;
            antalGæster = Data.GuestPerSpecificEmployee(name);
            for (int i = 0; i < antalGæster; i++)
            {
                Array.Resize<Guest>(ref guests, (antalArrayGæster + 1));
                guests[i] = new Guest(
                    Data.GuestNameList(name, i),
                    Data.GuestTLFList(name, i),
                    Data.GuestMailList(name, i),
                    Data.GuestPresentList(name, i),
                    Data.GuestRoomList(name, i));
                antalArrayGæster++;
            }
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

                    antalArrayGæster--;
                    //Array.Resize<Guest>(ref guests, (antalGæster + 1));
                    break;
                }
            }

            //Fjerne gæsten fra txt filen
            Data.RemoveGuestFromTXT(name);
        }

        public void AddGuest(Guest guest, Employee employee)
        {
            Array.Resize<Guest>(ref guests, (antalArrayGæster + 1));
            guests[antalGæster] = guest;
            antalGæster++;

            Data.AddGuestToTXT(guest, employee);
        }



    }
}



