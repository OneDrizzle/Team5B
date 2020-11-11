using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    public class Filter
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string  Filterclass { get; set; }
        public string Type { get; set; }
        public int LifespanInMonths { get; set; }

        public Filter(string manufacturer = "", string filterclass = "", string model = "", string type="", int lifespan=-1)
        {
            Manufacturer = manufacturer;
            Filterclass = filterclass;
            Model = model;
            Type = type;
            LifespanInMonths = lifespan;
        }
    }
}
