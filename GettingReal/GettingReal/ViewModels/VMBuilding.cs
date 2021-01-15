using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using GettingReal.Models;

namespace GettingReal.ViewModels
{
    public class VMBuilding
    {
        private Building _building;

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; _building.Name = _name; }
        }

        public List<VMVentilationAggregate> _ventilationAggregatesVM { get; set; }

    
        public VMBuilding(Building building)
        {
            this._building = building;
            _ventilationAggregatesVM = new List<VMVentilationAggregate>();
            foreach (VentilationAggregate aggregate in building.GetListOfVentilationAggregates())
            {
                _ventilationAggregatesVM.Add(new VMVentilationAggregate(aggregate));
            }

            Name = building.Name;
        }

        // Add a ventilation aggregate to the building
        public void AddVentilationAggregate(VMVentilationAggregate aggregateVM)
        {
            _ventilationAggregatesVM.Add(aggregateVM);
        }

        public Building GetBuilding()
        {
            return this._building;
        }

    }
}
