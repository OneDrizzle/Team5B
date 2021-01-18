using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal.Models
{
    [Serializable]
    public class Building
    {
        public string Name { get; set; }
        private List<VentilationAggregate> _ventilationAggregates;


        public Building(string name = "")
        {
            _ventilationAggregates = new List<VentilationAggregate>();
            Name = name;
        }
        public Building() : this("")
        { }

        // Gets a list of all ventilation aggregates associated with the building
        public List<VentilationAggregate> GetListOfVentilationAggregates()
        {
            return _ventilationAggregates;
        }

        // Add a ventilation aggregate to the building
        public void AddVentilationAggregate(VentilationAggregate ventilationAggregate)
        {
            _ventilationAggregates.Add(ventilationAggregate);
        }

        // Retrieve a spcific ventilation aggregate by ordernumber
        public VentilationAggregate GetVentilationAggregate(string orderNumber)
        {
            foreach (VentilationAggregate aggregate in _ventilationAggregates)
            {
                if (aggregate.OrderNumber == orderNumber)
                {
                    return aggregate;
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
