using GettingReal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal.ViewModels
{
    public class VMFloor
    {
        private Floor _floor;
        private string _number;

        public string Number
        {
            get { return _number; }
            set { _number = value; _floor.Number = _number; }
        }

        public List<VMRoom> _roomsVM { get; set; }


        public VMFloor(Floor floor)
        {
            this._floor = floor;
            _roomsVM = new List<VMRoom>();
            foreach (Room room in floor.GetListOfRooms())
            {
                _roomsVM.Add(new VMRoom(room));
            }

            Number = floor.Number;
        }

        public void AddRoom(VMRoom roomVM)
        {
            _roomsVM.Add(roomVM);
        }

        public Floor GetFloor()
        {
            return this._floor;
        }
    }
}
