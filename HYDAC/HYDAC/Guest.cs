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
        public Guest(string name, string phone, string mail)
        {
            _name = name;
            _phone = phone;
            _mail = mail;
        }
        public void SetPresence(bool present)
        {
            _present = present;
        }
    }
}
