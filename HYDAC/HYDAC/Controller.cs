using System;

namespace HYDAC
{
    public class Controller
    {
        private Employee[] employees = new Employee[100];
        private Employee selectedEmployee;
        private Guest selectedGuest; 
        private MeetingRoom[] meetingRooms = new MeetingRoom[20];
        private MeetingRoom selectedMeetingroom;
        
            
        public bool SelectEmployee(string name)
        {

            for (int i = 0; i < employees.Length; i++)
            {
                string temp = employees[i].GetName();

                if (name == temp)
                {
                    selectedEmployee = employees[i];
                    return true;
                }
            }

            return false;
        }

        public void RegisterGuest(string name, string phone, string mail)
        {
            selectedGuest = new Guest(name, phone, mail);
            selectedGuest.SetPresence(false);
            selectedEmployee.AddGuest(selectedGuest);

        }

        public bool SelectMeetingRoom(string name)
        {
            for (int i = 0; i < meetingRooms.Length; i++)
            {
                string tempName = meetingRooms[i].Name;
                if (tempName == name)
                {
                    selectedMeetingroom = meetingRooms[i];
                    selectedGuest.GoToMeetingRoom = selectedMeetingroom.Name;
                    // ikke implementeret: "sms bliver sendt til employee"
                    return true;
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

    }
}

