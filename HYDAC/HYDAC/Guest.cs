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

        public string Phone
        {
            get
            {
                return _phone;
            }
        }

        public string Mail
        {
            get
            {
                return _mail;
            }
        }

        public bool Present
        {
            get
            {
                return _present;
            }
        }

        public Guest(string name, string phone, string mail)
        {
            _name = name;
            _phone = phone;
            _mail = mail;
            _present = false;
        }

        public Guest(string name, string phone, string mail, string present, string room)
        {
            _name = name;
            _phone = phone;
            _mail = mail;
            _goToMeetingRoom = room;
            if (present == "true")
            {
                _present = true;
            }
            else 
            {
                _present = false;
            }
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

