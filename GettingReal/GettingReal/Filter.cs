using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    public class Filter
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string FilterClass { get; set; }
        public string Type { get; set; }
        public int LifespanInMonths { get; set; }

        public Filter(string manufacturer = "", string model = "", string filterClass = "", string type="", int lifespan=-1)
        {
            Manufacturer = manufacturer;
            Model = model;
            FilterClass = filterClass;
            Type = type;
            LifespanInMonths = lifespan;
        }
    }
}
