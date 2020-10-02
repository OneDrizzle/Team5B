using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace HYDAC
{
    public class Menu
    {
        private string title;
        private MenuItem[] menuItems = new MenuItem[10];
        private int itemCount = 0;

        public void AddMenuItem(string menuTitle)
        {
            MenuItem mi = new MenuItem(menuTitle);
            menuItems[itemCount] = mi;
            itemCount++;
        }

        public Menu(string title)
        {
            this.title = title;
        }

        public int SelectMenuItem()
        {
            int valg;
            bool isNumber;
            do
            {
                isNumber = int.TryParse(Console.ReadLine(), out valg);

                if (isNumber && valg >= 0 && valg <= itemCount)
                {
                    return valg;
                }

                if (isNumber)
                {
                    Console.WriteLine("Punkt findes ikke i menuen, prøv igen");
                }
                else
                {
                    Console.WriteLine("Input skal være et heltal i menuen, prøv igen");
                }


            } while (true);


        }


        public void Show()
        {
            
            Console.Clear();
            Console.WriteLine(title + "\n");

            string mellemrum = "   ";

            for (int i = 0; i < itemCount; i++)
            {
                Console.WriteLine(mellemrum + menuItems[i].Title);
            }

            Console.WriteLine("\n(Indtast menupunkt)");

        }

        public void DashBoard(Controller ct)
        {
            Console.Clear();
            int antalMennesker = Data.TotalCount();

            Console.WriteLine("Tilstedeværende personer i HYDAC: " + Data.TotalCount() + "\n");

            Console.WriteLine("Liste over medarbejdere mødt ind:");

            for (int i = 0; i < ct.Employees.Length; i++) //*************husk ændre 3 til emp.length
            {
                // bliver ikke vist ->>   0 = moodless
                if (ct.Employees[i].Humør != Employee.Mood.Moodless)    // 1 =      if humør == happy -> print( smiley )
                {                                                       // 2 = neutral
                                                                        // 3 = Sad
                    Console.Write("\t {0,-15} ", ct.Employees[i].Name);          // :-)  :-|   :-(

                    switch ((int)ct.Employees[i].Humør)
                    {
                        case 1:
                            Console.WriteLine(":-)");
                            break;

                        case 2:
                            Console.WriteLine(":-|");
                            break;

                        case 3:
                            Console.WriteLine(":-(");
                            break;
                    }
                }

            }

        }




    }
}
