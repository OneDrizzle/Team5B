using System.Collections.Generic;

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


        public void AddVentilationAggregate(string modelNumber, string orderNumber)
        {
            string fileName = customer.Company + "_" + building + "_" + orderNumber + ".pdf";

            aggregates.Add(new VentilationAggregate(modelNumber, orderNumber));
        }


        public VentilationAggregate GetVentilationAggregate(string orderNumber)
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


        public List<Filter> GetListOfFilters(VentilationAggregate selectedAggregate)
        {
            return selectedAggregate.GetListOfFilters();    
        }


        public void AddServiceReport(ServiceReport serviceReport)
        {
            selectedAggregate.AddServiceReport(serviceReport);
            selectedServiceReport = serviceReport;
        }

        public List<ServiceReport> GetListOfServiceReports(VentilationAggregate selectedAggregate)
        {
            return selectedAggregate.GetListOfServiceReports();
        }

    }
}
