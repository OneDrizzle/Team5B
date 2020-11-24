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

        public void AddFloor(Floor floor)
        {
            _floors.Add(floor);
        }

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


        public List<Floor> GetAllFloors()
        {
            return _floors;
        }

    }
}
