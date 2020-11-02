using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    public class Building
    {
        public string Name { get; set; }
        public double Area { get; set; }
        public List<Floor> floors;

        public Building(string name, double area)
        {
            Name = name;
            Area = area;
        }
    }
}
