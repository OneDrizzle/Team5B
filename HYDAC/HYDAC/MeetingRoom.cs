﻿namespace HYDAC
{
    public class MeetingRoom
    {
        private string _name;

        public MeetingRoom(string _name)
        {
            this._name = _name;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }



    }
}
