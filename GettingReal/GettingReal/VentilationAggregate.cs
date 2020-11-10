using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    public class VentilationAggregate
    {
        public string Date { get; private set; }
        public string OrderNumber { get; set; }

        private List<Filter> filters;
        private List<ServiceReport> serviceReports;
        private List<Floor> floors;

        public VentilationAggregate(string orderNumber = "0")        
        {
            filters = new List<Filter>();
            serviceReports = new List<ServiceReport>();
            floors = new List<Floor>();

            //DateTime date = new DateTime();
            //Date = date.Date;
            var date = DateTime.Now;        
            string Date = date.ToShortDateString();
        }

        public void AddServiceReport(ServiceReport serviceReport)
        {
            serviceReports.Add(serviceReport);
        }

        public ServiceReport GetServiceReport()
        {
            ServiceReport serviceReport;
            return serviceReport;
        }

        public List<ServiceReport> GetListOfServiceReports()
        {
            return serviceReports;
        }

        public void AddFilter(Filter filter)
        {
            filters.Add(filter);
        }

        public Filter GetFilter(string model)
        {
            foreach (Filter filter in filters)
            {
                if (filter.Model == model)
                {
                    return filter;
                }
            }
            return null;
        }

        public List<Filter> GetListOfFilters()
        {
            if (filters == null)
                return null;

            return filters;
        }

        //Maybe add floor methods if we decide they're needed

    }
}
