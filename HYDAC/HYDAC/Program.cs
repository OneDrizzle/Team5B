﻿using System;
using System.Security.Cryptography.X509Certificates;

namespace HYDAC
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller ct = new Controller();
            Menu mainMenu = new Menu("hovedmenu");
            string name = "Hans";
            int mood = 1;
            mainMenu.DashBoard(ct);
            
            ct.EmployeeArrival(name, mood);

            //Console.WriteLine(ct.Employees[0].Name);
            //Console.WriteLine(ct.Employees[0].Humør);

            //Console.WriteLine(ct.Employees[1].Name);
            //Console.WriteLine(ct.Employees[1].Humør);

            //Console.WriteLine(ct.Employees[2].Name);
            //Console.WriteLine(ct.Employees[2].Humør);

        }
    }
}
