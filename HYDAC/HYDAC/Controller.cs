using System;
using System.Linq;

namespace HYDAC
{
    public class Controller
    {
        private Employee[] employees;
        private Employee selectedEmployee;
        private Guest selectedGuest;
        private MeetingRoom[] meetingRooms = { new MeetingRoom("LilleStue", new Pamphlet("sikkerhedsfolder til Lillestue")),
                                               new MeetingRoom("StillingKantine", new Pamphlet("Sikkerhedsfolder til Kantine")),
                                               new MeetingRoom("StillingStueetage", new Pamphlet("Sikkerhedsfolder til Stueetage")) }; //*****indtast meetingrooms,sikkerhedsfolder*****
        private MeetingRoom selectedMeetingroom;

        public Employee[] Employees
        {
            get
            {
                return employees;
            }
            set
            {
                employees = value;
            }

        }

        public Controller()
        {
            int tal = Data.NrOfEmployess(); //Skal være max antal emplyees og ikke kun indmødte
            employees = new Employee[tal];
            string[] arrEmployee = new string[tal];

            for (int i = 0; i < tal; i++)
            {
                employees[i] = new Employee( Data.EmployeeNameList(i), Data.EmployeeMoodList(i)); 
            }
            
        }

        public bool SelectEmployee(string name)         //Metode til at finde Selected Employee
        {

            for (int i = 0; i < employees.Length; i++)  //tjekker employees igennem
            {
                string temp = employees[i].Name;   //navn på employee lægges ind i temp string

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
                Data.EmployeeSetMood(name, mood);
            }

        }

        public void EmployeeDeparture(string name)
        {
            bool checkEmployee = SelectEmployee(name);

            if (checkEmployee)
            {
                selectedEmployee.Humør = Employee.Mood.Moodless;
                Data.EmployeeSetMood(name, 0);
            }

        }

        public void InviteGuest()
        {
            Console.Write("Indtast dit navn: ");
            string employeeName = Console.ReadLine();
            SelectEmployee(employeeName);

            Console.WriteLine("Registrer gæst med navn, tlf, og mail");
            Console.Write("Navn: ");
            string guestName = Console.ReadLine();
            Console.Write("TLF: ");
            string guestTLF = Console.ReadLine();
            Console.Write("Email: ");
            string guestMail = Console.ReadLine();
            RegisterGuest(name: guestName, phone: guestTLF, mail: guestMail);

            Console.WriteLine("\nVælg mødelokale");
            Console.Write("1. LilleStue\t2. StillingKantine\t3. StillingStueetage");
            Console.WriteLine("\n(Indtast menupunkt)");
            int LokaleValg = int.Parse(Console.ReadLine());
            LokaleValg = LokaleValg - 1;

            string meetingRroom = meetingRooms[LokaleValg].Name;
            SelectMeetingRoom(meetingRroom);
            Data.AddGuestToTXT(selectedGuest, selectedEmployee);
        }


        public void SelectGuest(string guestName)
        {
            for (int i = 0; i < employees.Length; i++)  //tjekker employees igennem
            {
                if (Data.GuestPerSpecificEmployee(employees[i].Name) > 0)        //Tjekker om employee har mere end 0 gæster
                {
                    for(int j = 0; j < Data.GuestPerSpecificEmployee(employees[i].Name); j++)  //Kører så længe der er gæster i gæste
                    {
                        if (guestName == employees[i].Guests[j].Name)    //Hvis gæstens indtastede navn passer med et navn i emplyee gæste array
                        {
                            selectedGuest = employees[i].Guests[j];     //gæsten sættes til at være selected guest
                        }  
                    }
                }
            }
        }


        public void ReceiveGuest(string guestName)
        {
            SelectGuest(guestName);
            selectedGuest.SetPresence(true);            //gæst til stede sættes til true

            for(int i=0; i<meetingRooms.Length;i++)
            {
                if(selectedGuest.GoToMeetingRoom == meetingRooms[i].Name)
                {
                    selectedMeetingroom = meetingRooms[i];
                }
            }

            Console.WriteLine("Læs følgende: " + selectedMeetingroom.Pamphlet.Name); //Læs brochure
            Console.WriteLine("Vent på at en medarbejder henter dig");

            Data.GuestSetMood(guestName);
            //ikke implementeret - Besked sendes til medarbejder om ankomst 
        }

        public void CheckOutGuest(string employeeName)
        {
            SelectEmployee(employeeName);   

            Console.WriteLine("Indtast navn på gæst der skal tjekkes ud:");
            string guestName = Console.ReadLine(); //**************************************************************FLAGGED*****
            SelectGuest(guestName);
            //selectedGuest.SetPresence(false);            //gæst til stede sættes til false
            selectedEmployee.RemoveGuest(selectedGuest.Name);

        }

    }
}


