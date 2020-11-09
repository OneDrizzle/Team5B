﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace GettingReal
{
    public class VentilationAggregateRepository
    {
        private List<VentilationAggregate> aggregates;
        private VentilationAggregate selectedAggregate { get; set; }
        private ServiceReport selectedServiceReport { get; set; }
        private Filter selectedFilter { get; set; }
        private Room selectedRoom { get; set; }

    public VentilationAggregateRepository()
        {
            aggregates = new List<VentilationAggregate>();
        }

        
        public void AddAggregate(string modelNumber, string orderNumber)
        {
            string fileName = customer.Company + "_" + building + "_" + orderNumber + ".pdf";

            aggregates.Add(new VentilationAggregate(modelNumber, orderNumber));
        }


        public VentilationAggregate GetAggregate(string orderNumber)
        {
            foreach (VentilationAggregate aggregate in aggregates)
            {
                if (aggregate.OrderNumber == orderNumber)
                {
                    return aggregate;
                }
            }
            return null;
        }
        public void ShowAggregate(string orderNumber)
        {
            //Kig igennem mappe med aggregater og vælg fil ud fra ordrenummer
            //Vælg firma, og efterfølgende bygning, derefter vises en liste af aggregater under det firma i den bygning
            //Process.Start(new ProcessStartInfo(@"C:\Users\Danie\Desktop\ScrumReferenceCard.pdf") { UseShellExecute = true });
            Process.Start(new ProcessStartInfo(@"VE01.pdf") { UseShellExecute = true });
            //Firma_Bygning_Ordernummer.pdf
        }

        public void AddFilter(Filter filter)
        {
            selectedAggregate.AddFilter(filter);
        }

        public string GetFilterInfo()
        {
            return null;
        }

        public void AddServiceReport(ServiceReport serviceReport)
        {
            selectedAggregate.AddServicereport(serviceReport);
            selectedServiceReport = serviceReport;
        }
        public string GetServiceReport()
        {
            return null;
        }
    }
}