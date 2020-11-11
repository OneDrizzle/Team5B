﻿using System.Collections.Generic;

namespace GettingReal
{
    public class VentilationAggregateRepository
    {
        private List<VentilationAggregate> ventilationAggregates;
        private List<Filter> filters;
        private List<ServiceReport> serviceReports;
        private VentilationAggregate selectedAggregate { get; set; }
        private ServiceReport selectedServiceReport { get; set; }
        private Filter selectedFilter { get; set; }
        private Room selectedRoom { get; set; }

        public VentilationAggregateRepository()
        {
            ventilationAggregates = new List<VentilationAggregate>();
        }


        public bool AddVentilationAggregate(string orderNumber)
        {
            foreach (VentilationAggregate aggregate in ventilationAggregates)
            {
                if (aggregate.OrderNumber == orderNumber)
                {
                    return false;
                }
            }
            VentilationAggregate thisAggreate = new VentilationAggregate(orderNumber);
            ventilationAggregates.Add(thisAggreate);
            return true;
            //string fileName = customer.Company + "_" + building + "_" + orderNumber + ".pdf";

            //aggregates.Add(new VentilationAggregate(modelNumber, orderNumber));
        }


        public VentilationAggregate GetVentilationAggregate(string orderNumber)
        {
            foreach (VentilationAggregate aggregate in ventilationAggregates)
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
            return ventilationAggregates;
        }

        public List<Filter> GetAllFilters()
        {
            return filters;    
        }

        public List<ServiceReport> GetAllServiceReports()
        {
            return serviceReports;
        }



    }
}
