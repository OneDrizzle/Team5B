using GettingReal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal.ViewModels
{
    //VMRoom
    public class VMRoom
    {
        private Room _room;
        private string _number;

        public string Number
        {
            get { return _number; }
            set { _number = value; _room.Number = _number; }
        }

        public VMRoom(Room room)
        {
            Number = room.Number;
        }

        public Room GetRoom()
        {
            return this._room;
        }
    }
}
