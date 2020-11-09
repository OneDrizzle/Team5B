using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    public class BuildingRepository
    {
        List<Building> buildings;

        public BuildingRepository()
        {
            buildings = new List<Building>();
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

        public void Setbuilding()
        { }

        public void DeleteBuilding()
        { }
    }
}
