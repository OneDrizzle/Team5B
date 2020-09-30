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

        public string GetName()
        {
            return this.name;
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
            guests = new Guest[10];
            this.name = name;
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
            //tjeck navn på den givne gæst, og fjern gæsten fra array.

            for (int i = 0; i < guests.Length; i++)
            {
                string temp = guests[i].ToString();

                if (temp.Contains(name) == true)
                {
                    guests = guests.Where(e => e != guests[i]).ToArray();
                }
            }


            antalGæster--;

            //Fjerne gæsten fra txt filen
            string line = "";
            string templine = "";
            int count = 0;
            StreamReader reader = new StreamReader("Data_Guests.txt");
            while (reader.EndOfStream == false)
            {
                line = reader.ReadLine();
                count++;
            }
            reader.Close();

            string[] arr = new string[count];
            reader = new StreamReader("Data_Guests.txt");
            for (int i = 0; i < count; i++)
            {
                line = reader.ReadLine();
                templine = line.Substring(line.IndexOf(",") + 1);
                templine = templine.Remove(templine.IndexOf(","));
                if (templine != name)
                {
                    arr[i] = line;
                }


            }
            reader.Close();
            StreamWriter writer = new StreamWriter("Data_Guests.txt");
            for (int i = 0; i < count; i++)
            {
                
                if (!String.IsNullOrEmpty(arr[i]))
                {
                    writer.WriteLine(arr[i]);
                }
            }
            writer.Close();


        }

        public void AddGuest(Guest guest)
        {
            // hent data fra controller i form af et array 
            // insert data into guest array 
            // find ud af hvordan i indsætter mood i array, i den rigtige rakke føgle 
            //_guests[_guests.Length + 1] = guest;


            // finde ud af hvordan vi tjekker antal i huset (matematric " array.lenght / 4!" )



            // En måde og tjekke hvor mange pladser brugt. Length. Index´etc

            antalGæster++;
        }



    }
}



