using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal.Models
{
    [Serializable]
    public class BuildingRepository
    {

        private List<Building> _buildings;

        public BuildingRepository()
        {
            _buildings = new List<Building>();
        }

        public void AddBuilding(Building building)
        {
            _buildings.Add(building);
        }

        // Gets specific building by name
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

        // Gets the list of all buildings
        public List<Building> GetAllBuildings()
        {
            return _buildings;
        }

        // Sets a building, chosen by name, to the selected building
        public void Setbuilding(string name)
        {
            Building selectedBuilding;
            foreach (Building building in _buildings)
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
