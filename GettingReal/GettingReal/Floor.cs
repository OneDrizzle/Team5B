using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{   
    public class Floor
    {
        public string Number { get; set; }
        List<Room> rooms;

        public Floor(string number)
        {
            Number = number;
            rooms = new List<Room>();
        }

    }
}
