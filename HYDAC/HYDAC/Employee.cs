﻿namespace HYDAC
{
    public class Employee
    {
        private string _name;
        private Mood _mood;
        private Guest[] _guests;

        public enum Mood
        {
            Moodless,
            Sad,
            Neutral,
            Happy
        };

        public Employee(string name)
        {

        }
        public void AddGuest(Guest guest)
        {
            _guests[0] = guest;


            // hent data fra controller i form af et array 


            // insert data into guest array 


            // find ud af hvordan i indsætter mood i array, i den rigtige rakke føgle 


            // finde ud af hvordan vi tjekker antal i huset (matematric " array.lenght / 4!" )



            // En måde og tjekke hvor mange pladser brugt. Length. Index´etc

            //string date = DateTime.Now.ToString("dddd, dd MMMM");
            // dato, navn, firma, ansvarlig, ankomst, afgang, sikkerhedsfolder


        }
        public void RemoveGuest()
        {
            //tjeck navn på den givne gæst, og fjern gæsten fra array.
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
