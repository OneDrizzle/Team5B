using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    [Serializable]
    public class Customer
    {
        public string Name { get; set; }
        public string Company { get; set; }

        private List<Building> buildings;


        public Customer(string name = "", string company = "")
        {
            buildings = new List<Building>();
            Name = name;
            Company = company;
        }

        public Customer() : this("","")
        { }

        public List<Building> GetListOfBuildings()
        {
            return buildings;
        }

        public void AddBuilding(Building building)
        {
            buildings.Add(building);
        }

        public Building GetBuilding(string name)
        {
            foreach (Building building in buildings)
            {
                if (building.Name == name)
                {
                    return building;
                }
            }
            return null;
        }


        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
