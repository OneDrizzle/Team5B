using System;

namespace HydacMenu
{
    class Program
    {
        static void Main(string[] args)
        {

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
                    Console.ReadLine();*/
                    
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
            //nu kan det blive lidt svært

        }
    }
}
