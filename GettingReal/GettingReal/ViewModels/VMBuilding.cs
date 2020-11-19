using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using GettingReal.Models;

namespace GettingReal.ViewModels
{
    public class VMBuilding
    {
        private Building building;

        private string _name;

        public string Name
        {
            get { return _name; } 
            set { _name = value; building.Name = _name; }
        }

        public ObservableCollection<VMVentilationAggregate> _ventilationAggregatesVM { get; set; }


        public VMBuilding(Building building)
        {
            this.building = building;
            _ventilationAggregatesVM = new ObservableCollection<VMVentilationAggregate>();
            foreach (VentilationAggregate aggregateVM in building.GetListOfVentilationAggregates())
            {
                _ventilationAggregatesVM.Add(new VMVentilationAggregate(aggregateVM));
            }

            Name = building.Name;
        }

        // Add a ventilation aggregate to the building
        public void AddVentilationAggregate(VMVentilationAggregate aggregateVM)
        {
            _ventilationAggregatesVM.Add(aggregateVM);
            building.AddVentilationAggregate(aggregateVM.GetAggregate());
            VentilationAggregate agg new VentilationAggregate();
            agg.OrderNumber = aggregateVM.OrderNumber;
            agg.FileName = vmagg.FileName;
            building.AddVentilationAggregate(agg);
        }

    }
}
