using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal.Models
{
    [Serializable]
    public class Customer
    {
        public string Name { get; set; }
        public string Company { get; set; }

        private List<Building> _buildings;


        public Customer(string name = "", string company = "")
        {
            _buildings = new List<Building>();
            Name = name;
            Company = company;
        }

        public Customer() : this("", "")
        { }

        public List<Building> GetListOfBuildings()
        {
            return _buildings;
        }

        public void AddBuilding(Building building)
        {
            _buildings.Add(building);
        }

        public Building GetBuilding(string name)
        {
            foreach (Building building in _buildings)
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
