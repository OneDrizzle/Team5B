using System;
using System.Linq;

namespace HYDAC
{
    public class Controller
    {
        private Employee[] employees;
        private Employee selectedEmployee;
        private Guest selectedGuest;
        private MeetingRoom[] meetingRooms = { new MeetingRoom("LilleStue", new Pamphlet("Sikkerhedsfolder til Lillestue")),
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
            int optaltFraTxt= 10;
            employees = new Employee[optaltFraTxt]; 
            employees[0] = new Employee("Hans");
            employees[1] = new Employee("Per");
            employees[2] = new Employee("Jens",1);
         
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
            selectedEmployee.AddGuest(selectedGuest, selectedEmployee);       //Selected guest bliver added til selected employee's gæste array

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
            SelectEmployee(employeeName); // sætter Hans til at være selectedEmployee

            Console.WriteLine("Registrer gæst med navn, tlf, og mail");
            Console.Write("Navn: ");
            string guestName = Console.ReadLine();
            Console.Write("TLF: ");
            string guestTLF = Console.ReadLine();
            Console.Write("Email: ");
            string guestMail = Console.ReadLine();
            RegisterGuest(name: guestName, phone: guestTLF, mail: guestMail);

            Console.WriteLine("Vælg mødelokale");
            Console.Write("LilleStue tast : 1");
            Console.Write("StillingKantine tast : 2");
            Console.Write("StillingStueetage tast : 3");


            int LokaleValg = int.Parse(Console.ReadLine());
            LokaleValg = LokaleValg - 1;

            string meetingRroom = meetingRooms[LokaleValg].Name; // ********
            SelectMeetingRoom(meetingRroom);
        }


        public void SelectGuest(string guestName)
        {
            for (int i = 0; i < employees.Length; i++)  //tjekker employees igennem
            {
                if (employees[i].AntalGæster > 0)        //Tjekker om employee har mere end 0 gæster
                {
                    for(int j = 0; j < selectedEmployee.AntalGæster; j++)  //Kører så længe der er gæster i gæste
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
            //int j = 0;
            //int counter = 0;
            Console.WriteLine("Indtast dit navn");

            SelectGuest(guestName); // sleected gæst bliver valgt ud fra navn
            selectedGuest.SetPresence(true);            //gæst til stede sættes til true

            for(int i=0; i<meetingRooms.Length;i++)
            {
                if(selectedGuest.GoToMeetingRoom == meetingRooms[i].Name)
                {
                    selectedMeetingroom = meetingRooms[i];
                }
            }

            Console.WriteLine("læs følgende: " + selectedMeetingroom.Pamphlet.Name); //Læs brochure
            Console.WriteLine("gå til: " + selectedGuest.GoToMeetingRoom);

            //ikke implementeret - Besked sendes til medarbejder om ankomst 
        }

        public void CheckOutGuest(string employeeName)
        {
            //Console.WriteLine("vælg employee");
            //string employeeName = Console.ReadLine();   //Selecter employee
            SelectEmployee(employeeName);   //sætter selectedEmployee til navnet

            //Console.WriteLine("vælg gæst du vil tjekke ud");
            string guestName = Console.ReadLine(); //**************************************************************FLAGGED*****
            SelectGuest(guestName);
            //selectedGuest.SetPresence(false);            //gæst til stede sættes til false
            selectedEmployee.RemoveGuest(selectedGuest.Name);

        }

    }
}


