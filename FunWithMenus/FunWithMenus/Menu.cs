﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace FunWithMenus
{
    class Menu
    {
        public string Title;
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
            Title = title;
        }

        public int SelectMenuItem()
        {
            int valg;
            bool isNumber;
            do
            {
                isNumber = int.TryParse(Console.ReadLine(), out valg);

                if(isNumber && valg >= 0 && valg <= itemCount)
                {
                    return valg;
                }
                
                if(isNumber)
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
                Console.WriteLine(Title + "\n");

                string mellemrum = "   ";

                for (int i = 0; i < itemCount; i++)
                {
                    Console.WriteLine(mellemrum + menuItems[i].Title);
                }

            Console.WriteLine("\n(Tryk menupunkt eller 0 for at afslutte)");

            

        }
    }
}
