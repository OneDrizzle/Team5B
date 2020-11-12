using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    [Serializable]
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

        public Room GetRoom(string number)
        {
            foreach (Room room in rooms)
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
            foreach (Room room in rooms)
            {
                if (room.Number == number)
                {
                    SelectedRoom = room;
                }
            }
        }


        public List<Room> GetAllRooms()
        {
            return rooms;
        }

        //public void DeleteRoom()
        //{

        //}

    }
}
