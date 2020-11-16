using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    [Serializable]
    public class RoomRepository
    {
        private List<Room> _rooms;

        public RoomRepository()
        {
            _rooms = new List<Room>();
        }

        public void AddRoom(Room room)
        {
            _rooms.Add(room);
        }

        public Room GetRoom(string number)
        {
            foreach (Room room in _rooms)
            {
                if (room.Number == number)
                {
                    return room;
                }
            }
            return null;
        }

        public void SetRoom(string number)
        {
            Room SelectedRoom;
            foreach (Room room in _rooms)
            {
                if (room.Number == number)
                {
                    SelectedRoom = room;
                }
            }
        }


        public List<Room> GetAllRooms()
        {
            return _rooms;
        }

        //public void DeleteRoom()
        //{

        //}

    }
}
