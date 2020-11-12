using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    [Serializable]
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

        public List<Building> GetAllBuildings()
        {
            return buildings;
        }

        public void Setbuilding(string name)
        {
            Building selectedBuilding;
            foreach (Building building in buildings)
            {
                if (building.Name == name)
                {
                    selectedBuilding = building;
                }
            }
        }

        public void DeleteBuilding()
        { }
    }
}
