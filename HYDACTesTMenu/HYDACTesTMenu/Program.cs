using HYDAC;
using HYDACTesTMenu;
using System;

namespace HydacMenu
{
    class Program
    {
        static void Main(string[] args)
        {






















            /*

            Employee emp = new Employee("hans");

            Employee selectedEmployee;
            Guest selectedGuest;

            selectedGuest = new Guest("john", "111111", "mail");
            emp.AddGuest(selectedGuest);
            selectedGuest = new  Guest("john2", "222222", "mail");
            emp.AddGuest(selectedGuest);

            emp.RemoveGuest("john");

            selectedGuest = new Guest("brian", "333333", "mail");
            emp.AddGuest(selectedGuest);
            selectedGuest = new Guest("mikkel", "444444", "mail");
            emp.AddGuest(selectedGuest);


            Console.ReadLine();



            */




            /*
            Guest[] _guests = new Guest[10];
            int counter = 0; // holder styr på hvor mange gæster der er oprettet

            _guests[0] = new Guest("John", "00000", "mail");
            counter++;
            _guests[1] = new Guest("Hans", "11111", "mail");
            counter++;
            _guests[2] = new Guest("Peter", "22222", "mail");
            counter++; // counter er nu 3
            
            string name = "Hans"; //navn på gæst der skal fjernes fra _guests[] array
            
            Console.WriteLine("gamle gæste-array:");

            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine(_guests[i].Name + "" + i); // udskriver gæster før vi laver ændringer + deres plads i arrayet

                // da der jo altid er op til 10 pladser var jeg nødt til at bruge 'counter' hele vejen ellers->
                // kom der null exception hvis jeg prøvede at udskrive fx [3] eller [4]...[9] 
            }

            Guest[] temp = new Guest[counter]; //opretter et temp[] Guest array

            int j = 0;
            int tempcounter = counter; //midlertidig counter der ved hvor mange gæster der var oprettet i _guests[]
            for (int i = 0; i < tempcounter; i++)
            {
                if (_guests[i].Name != name) 
                {
                    temp[i-j] = _guests[i];  //tilføjer kun gæst i temp[] array hvis navnet ikke er "Hans"
                }
                else
                {
                    j++;   // 'j' sørger for at vi sætter elementer ind på den korrekte plads i vores temp[] array --->
                           // uden 'j' ville vi sætte [0]=[0] og [2]=[2] ... da 1=1 springes overeftersom gæsten hedder "Hans"->
                           // og derfor skal vi sætte [0]=[0] og [1]=[2] så "Peter" får den rigtige plads i temp[] array

                    counter--;  // holder styr på det antallet af elementer i temp[] array
                }
            }

            Console.WriteLine("\nNye gæste-array:");

            for (int i = 0; i < counter; i++)
            {
                _guests[i] = temp[i]; // her sætter vi _guests[] tilbage til det temp[] array vi lavede
                Console.WriteLine(_guests[i].Name + "" + i); // udskriver det ændrede _guest[] array + gæstens plads i arrayet
            }

            Console.ReadKey();











            /*
            Console.Clear();
            Console.Write("\n\t\t\t\t\t\t\tHydac Menu\n\n\n\t\t\t\t\t1. Login \t2. Admin login \t\t3. exit\n\nt\t\t\t\t\t\t\tChose menu: ");
            int parseMenu;
            string menuInput = Console.ReadKey();
            if (int.TryParse(menuInput, out parseMenu) == true)
            {
                if (menuInput.key == ConsoleKey.D1)
                {
                    Console.Clear();
                    Console.WriteLine("\n\t\t\t\t\t\t\tHydac Menu\n\n\n\t\t\t\t\tThis is menu:{0}", parseMenu);
                    Console.ReadLine();

                }
                else if (parseMenu == 2)
                {
                    Console.Clear();
                    Console.WriteLine("This is menu:{0}\n\t\t\t\t\t\t\tHydac Menu\n\n\n\t\t\t\t\tThis is menu:{0}", parseMenu);
                    Console.ReadLine();
                }
                else if (menuInput.Key == ConsoleKey.D3)
                {
                    /*Console.Clear();
                    Console.WriteLine("This is menu:{0}\n\t\t\t\t\t\t\tHydac Menu\n\n\n\t\t\t\t\tThis is menu:{0}", parseMenu);
                    Console.ReadLine();
                    
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n\t\t\t\t\t\t\tHydac Menu\n\n\n\t\t\t\t\tThere is none menu, with the number: {0}", parseMenu);
                    Console.ReadLine();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\n\t\t\t\t\t\t\tHydac Menu\n\n\n\t\t\t\t\tinvalid input!");
                Console.ReadLine();
            }

            //GitHub kan blive godt.
            //Her kan det blive svært når der er to der laver noget i samme fil
            //nu kan det blive lidt svært
            //It works? :o
            */
        }
    }
}
