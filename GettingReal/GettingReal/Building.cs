using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
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

        public List<VentilationAggregate> GetListOfVentilationAggregates()
        {
            return _ventilationAggregates;
        }

        public void AddVentilationAggregate(VentilationAggregate ventilationAggregate)
        {
            _ventilationAggregates.Add(ventilationAggregate);
        }

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
