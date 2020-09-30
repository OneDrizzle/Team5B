﻿using System;
using System.Linq;

namespace HYDAC
{
    public class Controller
    {
        private Employee[] employees = new Employee[100];
        private Employee selectedEmployee;
        private Guest selectedGuest;
        private MeetingRoom[] meetingRooms = { new MeetingRoom("LilleStue", new Pamphlet("sikkerhedsfolder til Lillestue")),
                                               new MeetingRoom("StillingKantine", new Pamphlet("Sikkerhedsfolder til Kantine")),
                                               new MeetingRoom("StillingStueetage", new Pamphlet("Sikkerhedsfolder til Stueetage")) }; //*****indtast meetingrooms,sikkerhedsfolder*****
        private MeetingRoom selectedMeetingroom;


        public bool SelectEmployee(string name)         //Metode til at finde Selected Employee
        {

            for (int i = 0; i < employees.Length; i++)  //tjekker employees igennem
            {
                string temp = employees[i].GetName();   //navn på employee lægges ind i temp string

                if (name == temp)                       //Tjekker om name er samme som temp name
                {
                    selectedEmployee = employees[i];    //Vælger employee
                    return true;                        //Hvis den finder employee med korrekt 'name' return true
                }
            }

            return false;                               //Hvis den ikke finder employee med korrekt 'name' return false
        }

        public void RegisterGuest(string name, string phone, string mail)   //Metode til oprettelse af guest
        {
            selectedGuest = new Guest(name, phone, mail);   //Opretter/instantiere guest og tilføjer de tilhørende data             
            selectedEmployee.AddGuest(selectedGuest);       //Selected guest bliver added til selected employee's gæste array

        }

        public bool SelectMeetingRoom(string name)          //Metode til valg af meeting room
        {
            for (int i = 0; i < meetingRooms.Length; i++)
            {
                string tempName = meetingRooms[i].Name;     //Name sammenligned med meetingroom names ->
                if (tempName == name)                       //Udføres hvis name og meetingroom name er ens
                {
                    selectedMeetingroom = meetingRooms[i];                      //Det søgte meetingroom er nu det valgte meetingroom
                    selectedGuest.GoToMeetingRoom = selectedMeetingroom.Name;   //Navn på selected meetingroom er lig med det meetingroom gæsten skal gå til
                    // ikke implementeret: "sms bliver sendt til employee"
                    return true;                            //Hvis den finder meetingroom return true ellers false
                }
            }
            return false;
        }



        public void EmployeeArrival(string name, int mood)
        {
            bool checkEmployee = SelectEmployee(name); //hvis sandt - så indeholder selectedEmployee den medarb. med indtastede name. 

            if (checkEmployee)
            {
                selectedEmployee.Humør = (Employee.Mood)mood;
            }

        }

        public void EmployeeDeparture(string name)
        {
            bool checkEmployee = SelectEmployee(name);

            if (checkEmployee)
            {
                selectedEmployee.Humør = Employee.Mood.Moodless;
            }

        }

        public void InviteGuest()
        {
            Console.WriteLine("vælg employee");
            string employeeName = Console.ReadLine();
            SelectEmployee(employeeName);

            Console.WriteLine("Registrer gæst med navn, tlf, og mail");
            string guestName = Console.ReadLine();
            string guestTLF = Console.ReadLine();
            string guestMail = Console.ReadLine();
            RegisterGuest(name: guestName, phone: guestTLF, mail: guestMail);

            Console.WriteLine("Vælg mødelokale");
            Console.Write("LilleStue tast : 1");
            Console.Write("StillingKantine tast : 2");
            Console.Write("StillingStueetage tast : 3");
            int LokaleValg = int.Parse(Console.ReadLine());
            LokaleValg = LokaleValg - 1;
            
            string meetingRroom = meetingRooms[LokaleValg].Name;
            SelectMeetingRoom(meetingRroom);
        }

        public void ReceiveGuest(string name)
        {
            int j = 0;
            int counter = 0;
            //gæst til stede sættes til true
            Console.WriteLine("Indtast dit navn");


            for (int i = 0; i < employees.Length; i++)  //tjekker employees igennem
            {
                if(employees[i].AntalGæster > 0)
                {
                    while (employees[i].Guests[j] != null)
                    {
                        if (name == employees[i].Guests[j].Name)
                        {
                            selectedGuest = employees[i].Guests[j];
                            
                        }
                        j++;
                    }
                    j = 0;
                }

            }
            
            selectedGuest.SetPresence(true);
            Console.WriteLine("gå til: " + selectedGuest.GoToMeetingRoom);

            for(int i=0; i<meetingRooms.Length;i++)
            {
                if(selectedGuest.GoToMeetingRoom == meetingRooms[i].Name)
                {
                    selectedMeetingroom = meetingRooms[i];
                }
            }

            Console.WriteLine("læs følgende: " + selectedMeetingroom.Pamplet); //Læs brochure

            //ikke implementeret - Besked sendes til medarbejder om ankomst 
        }

        public void CheckOutGuest()
        {

        }

    }
}


