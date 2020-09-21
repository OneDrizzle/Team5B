using System;
using System.ComponentModel;
using System.Globalization;

namespace FunWithMenus
{
    class Program
    {

        static void Main(string[] args)
        {

            Menu mainMenu = new Menu("Min fantastiske Menu");

            // First menu 
            mainMenu.AddMenuItem("1. Gør dit");
            mainMenu.AddMenuItem("2. Gør dat");
            mainMenu.AddMenuItem("3. Gør noget");
            mainMenu.AddMenuItem("4. Få svaret på livet, universet og alting");

            mainMenu.Show();

            int itemid = mainMenu.SelectMenuItem();

            switch (itemid)
            {
                case 1:
                    Console.WriteLine("gør dit");
                    break;

                case 2:
                    Console.WriteLine("gør dat");
                    break;

                case 3:
                    Console.WriteLine("gør noget");
                    break;

                case 4:
                    Console.WriteLine("42");
                    break;
            }
            

            Console.ReadLine();

        }
    }
}
