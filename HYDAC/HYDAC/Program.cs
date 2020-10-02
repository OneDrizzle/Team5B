using System;
using System.Security.Cryptography.X509Certificates;

namespace HYDAC
{
    class Program
    {
        static void Main(string[] args)
        {
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

                mainMenu.Show();
                int valg = mainMenu.SelectMenuItem();

                if (valg == 1)  //Medarbejder stuffs here
                {
                    mainMenu.DashBoard(ct);
                    Console.WriteLine("\n(Tryk på en tast for at fortsætte...)");
                    Console.ReadLine();

                    subMenu.Show();
                    int valg2 = subMenu.SelectMenuItem();

                    if (valg2 == 1) //Tjek ind
                    {
                        Console.Clear();
                        Console.Write("Indtast venligst dit navn: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Vælg Humør:\n1. :-)\t\t2. :-|\t\t3. :-(");
                        int mood = int.Parse(Console.ReadLine());

                        ct.EmployeeArrival(name, mood);
                        Console.WriteLine("Velkommen til! Du er blevet tjekket ind!");
                        Console.ReadLine();

                    }


                    if (valg2 == 2) //Tjek ud
                    {
                        Console.Write("Indtast navn: ");
                        string name = Console.ReadLine();
                        ct.EmployeeDeparture(name);
                        Console.WriteLine("\nDu er blevet tjekket ud!");
                        Console.ReadLine();
                    }


                    if (valg2 == 3) //Inviter gæst
                    {
                        Console.Clear();
                        ct.InviteGuest();
                        Console.WriteLine("Gæst inviteret!");
                        Console.ReadLine();

                    }


                    if (valg2 == 4) //Tjek gæst ud
                    {
                        Console.Clear();
                        Console.WriteLine("Tjek gæst ud.");
                        Console.Write("\nIndtast dit navn: ");
                        string employeeName = Console.ReadLine();
                        ct.CheckOutGuest(employeeName);
                        Console.Write("Gæsten er nu blevet tjekket ud!");
                        Console.ReadLine();
                    }

                    if (valg == 5) //Gå tilbage
                    {
                        continue;
                    }


                }


                if (valg == 2)  //Gæste stuff here
                {
                    Console.Clear();
                    Console.Write("Indtast venligst dit navn: ");
                    string guest = Console.ReadLine();
                    ct.ReceiveGuest(guest);
                    Console.WriteLine("Velkommen til HYDAC! Du er blevet tjekket ind!");
                    Console.ReadLine();
                }

                if (valg == 3)  //Afslutter
                {
                    Console.WriteLine("Afslutter.");
                    Console.ReadLine();
                    break;          //Braker ud af menuen og aslutter programmet
                }

            }
        }
    }
}
