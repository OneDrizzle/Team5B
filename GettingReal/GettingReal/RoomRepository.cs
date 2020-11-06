using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    public class RoomRepository
    {
        private List<Room> rooms;

        public RoomRepository()
        {
            rooms = new List<Room>();
        }

        public void AddRoom(Room room)
        {
            rooms.Add(room);
        }

    }
}
