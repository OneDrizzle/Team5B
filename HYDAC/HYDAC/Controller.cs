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
            return null;

            // ikke implementeret: "sms bliver sendt til employee"
        }

    }
}

