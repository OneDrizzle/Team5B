using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal.Models
{
    [Serializable]
    public class Floor
    {
        public string Number { get; set; }
        List<Room> _rooms;

        public Floor(string number)
        {
            Number = number;
            _rooms = new List<Room>();
        }

        public Floor() : this("0")
        {
        }

        public List<Room> GetListOfRooms()
        {
            return _rooms;
        }

        public void AddRoom(Room room)
        {
            _rooms.Add(room);
        }



    }
}
