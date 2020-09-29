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
                    Console.WriteLine("punkt findes ikke i menuen, prøv igen");
                }
                else
                {
                    Console.WriteLine("input skal være et heltal i menuen, prøv igen");
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

            Console.WriteLine("\n(Tryk menupunkt eller 0 for at afslutte)");

        }


        static public int EmployeeCount()
        {
            StreamReader reader = new StreamReader("Data_Employee.txt");
            string line = "";
            string moodvalue;
            int count = 0;
            while (reader.EndOfStream == false)
            {

                line = reader.ReadLine();
                moodvalue = line.Substring(line.LastIndexOf(",") + 1);

                if (moodvalue != "0")
                {
                    count++;
                }
            }
            reader.Close();

            return count;
        }

        static public int GuestCount()
        {
            StreamReader reader = new StreamReader("Data_Guest.txt");
            string line = "";
            string present;
            int count = 0;
            while (reader.EndOfStream == false)
            {

                line = reader.ReadLine();
                present = line.Substring(line.LastIndexOf(",") + 1);

                if (present == "true")
                {
                    count++;
                }
            }
            reader.Close();

            return count;
        }

        static public int TotalCount()
        {
            return EmployeeCount() + GuestCount();
        }

    }
}
