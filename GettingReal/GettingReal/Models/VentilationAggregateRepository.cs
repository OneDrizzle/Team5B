using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal.Models
{

    [Serializable]
    public class VentilationAggregateRepository
    {
        private List<VentilationAggregate> _ventilationAggregates;
        private List<Filter> _filters;
        private List<ServiceReport> _serviceReports;
        private VentilationAggregate selectedAggregate { get; set; }
        private ServiceReport selectedServiceReport { get; set; }
        private Filter selectedFilter { get; set; }
        private Floor selectedRoom { get; set; }

        public VentilationAggregateRepository()
        {
            _ventilationAggregates = new List<VentilationAggregate>();
        }


        public VentilationAggregate AddVentilationAggregate(string orderNumber, string fileName)
        {
            //foreach (VentilationAggregate aggregate in _ventilationAggregates)
            //{
            //    if (aggregate.OrderNumber == orderNumber)
            //    {
            //        return false;
            //    }
            //}
            VentilationAggregate thisAggreate = new VentilationAggregate(orderNumber, fileName);
            _ventilationAggregates.Add(thisAggreate);
            return thisAggreate;
            //string fileName = customer.Company + "_" + building + "_" + orderNumber + ".pdf";

            //aggregates.Add(new VentilationAggregate(modelNumber, orderNumber));
        }
        public bool AddVentilationAggregate(VentilationAggregate ag)
        {
            //foreach (VentilationAggregate aggregate in ventilationAggregates)
            //{
            //    if (aggregate.OrderNumber == ag.OrderNumber)
            //    {
            //        return false;
            //    }
            //}
            _ventilationAggregates.Add(ag);
            return true;
            //string fileName = customer.Company + "_" + building + "_" + orderNumber + ".pdf";

            //aggregates.Add(new VentilationAggregate(modelNumber, orderNumber));
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

        /*
        public void ShowAggregate(string orderNumber)
        {
            //Kig igennem mappe med aggregater og vælg fil ud fra ordrenummer
            //Vælg firma, og efterfølgende bygning, derefter vises en liste af aggregater under det firma i den bygning
            //Process.Start(new ProcessStartInfo(@"C:\Users\Danie\Desktop\ScrumReferenceCard.pdf") { UseShellExecute = true });
            Process.Start(new ProcessStartInfo(@"VE01.pdf") { UseShellExecute = true });
            //Firma_Bygning_Ordernummer.pdf
        }
        */


        public void AddFilter(Filter filter)
        {
            selectedAggregate.AddFilter(filter);
        }

        public void AddServiceReport(ServiceReport serviceReport)
        {
            selectedAggregate.AddServiceReport(serviceReport);
            selectedServiceReport = serviceReport;
        }

        public List<VentilationAggregate> GetAllVentilationAggregates()
        {
            return _ventilationAggregates;
        }

        public List<Filter> GetAllFilters()
        {
            return _filters;
        }

        public List<ServiceReport> GetAllServiceReports()
        {
            return _serviceReports;
        }



    }
}
