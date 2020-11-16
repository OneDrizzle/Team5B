using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
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

        public List<Building> GetAllBuildings()
        {
            return _buildings;
        }

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
