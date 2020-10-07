using System;
using System.Security.Cryptography.X509Certificates;

namespace HYDAC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Team 5B HYDAC";
            Controller ct = new Controller();
            Menu mainMenu = new Menu("HYDAC hovedmenu");

            mainMenu.AddMenuItem("1. Medarbejder");
            mainMenu.AddMenuItem("2. Gæst");
            mainMenu.AddMenuItem("3. Afslut program");

            Menu subMenu = new Menu("HYDAC medarbejder login");

            subMenu.AddMenuItem("1. Tjek ind");
            subMenu.AddMenuItem("2. Tjek ud");
            subMenu.AddMenuItem("3. Inviter gæst");
            subMenu.AddMenuItem("4. Tjek gæst ud");
            subMenu.AddMenuItem("5. Gå tilbage");

            while (true)
            {

                mainMenu.DashBoard(ct);
                mainMenu.Show();
                int valg = mainMenu.SelectMenuItem();

                if (valg == 1)  //Medarbejder stuffs here
                {
                  
                    subMenu.Show();
                    int valg2 = subMenu.SelectMenuItem();

                    if (valg2 == 1) //Tjek ind
                    {
                        Console.Clear();
                        Console.Write("Velkommen medarbejder, indtast dit navn: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("\nHvilket humør har du i dag?");
                        Console.Write("\n (1) :-)\n (2) :-|\n (3) :-(\n\nVælg Humør: ");
                        int mood = int.Parse(Console.ReadLine());

                        ct.EmployeeArrival(name, mood);
                        Console.WriteLine("\nDu er nu blevet tjekket ind\n\n(tryk på en tast for at vende tilbage til oversigten)");
                        Console.ReadKey();
                    }

                    else if (valg2 == 2) //Tjek ud
                    {
                        Console.Clear();
                        Console.Write("Indtast navn for at tjekke ud: ");
                        string name = Console.ReadLine();
                        ct.EmployeeDeparture(name);
                        Console.WriteLine("\n\nDu er nu blevet tjekket ud\n\n(tryk på en tast for at vende tilbage til oversigten)");
                        Console.ReadKey();
                    }

                    else if (valg2 == 3) //Inviter gæst
                    {
                        Console.Clear();
                        ct.InviteGuest();
                        Console.WriteLine("\nGæst oprettet i systemet\n\n(tryk på en tast for at vende tilbage til oversigten)");
                        Console.ReadKey();
                    }

                    else if (valg2 == 4) //Tjek gæst ud
                    {
                        Console.Clear();
                        Console.Write("Indtast navn på medarbejder: ");
                        string employeeName = Console.ReadLine();
                        ct.CheckOutGuest(employeeName);
                        Console.Write("\nGæsten er nu blevet tjekket ud\n\n(tryk på en tast for at vende tilbage til oversigten)");
                        Console.ReadKey();
                    }

                    else if (valg == 5) //Gå tilbage
                    {
                        continue;
                    }


                }


                else if (valg == 2)  //Gæste stuff here
                {
                    Console.Clear();
                    Console.Write("Velkommen til HYDAC, indtast venligst dit navn: ");
                    string guest = Console.ReadLine();
                    ct.ReceiveGuest(guest);
                    Console.Write("\n\n(tryk på en tast for at vende tilbage til oversigten)");
                    Console.ReadKey();
                }

                else if (valg == 3)  //Afslutter
                {  
                    break;          //Braker ud af menuen og aslutter programmet
                }

            }
        }
    }
}
