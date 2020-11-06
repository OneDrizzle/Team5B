using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace GettingReal
{
    public class AggregateRepository
    {
        List<Aggregate> aggregates;
        private Aggregate selectedAggregate { get; set; }
        private ServiceReport selectedServiceReport { get; set; }
        private Filter selectedFilter { get; set; }
        private Room selectedRoom { get; set; }

    public AggregateRepository()
        {
            aggregates = new List<Aggregate>();
        }

        
        public void AddAggregate(string modelNumber, string orderNumber, Customer customer)
        {
            string fileName = customer.Company + "_" + building + "_" + orderNumber + ".pdf";

            aggregates.Add(new Aggregate(modelNumber, orderNumber, fileName, company));
        }


        public Aggregate GetAggregate(string orderNumber)
        {
            foreach (Aggregate aggregate in aggregates)
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
            selectedAggregate.filters.Add(filter);
        }

        public string GetFilterInfo()
        {
            return null;
        }

        public void AddServiceReport(ServiceReport serviceReport)
        {
            selectedAggregate.serviceReports.Add(serviceReport);
            selectedServiceReport = serviceReport;
        }
        public string GetServiceReport()
        {
            return null;
        }
    }
}
