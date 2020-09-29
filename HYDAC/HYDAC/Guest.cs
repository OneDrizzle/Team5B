using System;
using System.Collections.Generic;
using System.Text;

namespace HYDAC
{
    public class Guest
    {
        private string _name;
        private string _phone;
        private string _mail;
        private bool _present;
        private string _goToMeetingRoom;


        public string Name
        {
            get 
            {
                return _name;
            }
        }

        public Guest(string name, string phone, string mail)
        {
            _name = name;
            _phone = phone;
            _mail = mail;
            _present = false;
        }
        public void SetPresence(bool present)
        {
            _present = present;
        }

        public string GoToMeetingRoom
        {
            get
            {
                return _goToMeetingRoom;
            }    
            set
            {
                _goToMeetingRoom = value;
            }
        }
    }
}

