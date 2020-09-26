using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace HYDAC
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
            this._name = name;
        }
        public void AddGuest(Guest guest)
        {
            // hent data fra controller i form af et array 
            // insert data into guest array 
            // find ud af hvordan i indsætter mood i array, i den rigtige rakke føgle 
            _guests[_guests.Length + 1] = guest;


            // finde ud af hvordan vi tjekker antal i huset (matematric " array.lenght / 4!" )



            // En måde og tjekke hvor mange pladser brugt. Length. Index´etc





        }
        public void RemoveGuest(string name)
        {
            //tjeck navn på den givne gæst, og fjern gæsten fra array.

            for (int i = 0; i < _guests.Length; i++)
            {
                string temp = _guests[i].ToString();

                if (temp.Contains(name) == true)
                {
                    _guests
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
