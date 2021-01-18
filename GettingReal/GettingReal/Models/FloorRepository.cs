using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal.Models
{
    [Serializable]
    public class FloorRepository
    {
        private List<Floor> _floors;

        public FloorRepository()
        {
            _floors = new List<Floor>();
        }

        // Adds a floor to the list of floors
        public void AddFloor(Floor floor)
        {
            _floors.Add(floor);
        }

        // returns a floor based on number/name of the floor
        public Floor GetFloor(string number)
        {
            foreach (Floor floor in _floors)
            {
                if (floor.Number == number)
                {
                    return floor;
                }
            }
            return null;
        }

        // Sets specific floor, selected by "number", as selected floor
        public void SetFloor(string number)
        {
            Floor SelectedFloor;
            foreach (Floor floor in _floors)
            {
                if (floor.Number == number)
                {
                    SelectedFloor = floor;
                }
            }
        }

        // returns a list of all floors
        public List<Floor> GetAllFloors()
        {
            return _floors;
        }

    }
}
