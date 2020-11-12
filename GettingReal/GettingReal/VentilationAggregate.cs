using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    [Serializable]
    public class VentilationAggregate
    {
        public string InstallDate { get; set; }
        public string OrderNumber { get; set; }

        private List<Filter> filters;
        private List<ServiceReport> serviceReports;
        //private List<Floor> floors;


        public VentilationAggregate(string orderNumber = "0", string date = "EmptyDate")        
        {
            filters = new List<Filter>();
            serviceReports = new List<ServiceReport>();
            //floors = new List<Floor>();

            if (date == "EmptyDate")
            {
                var dateToday = DateTime.Now;
                date = dateToday.ToShortDateString();
            }
            InstallDate = date;
            OrderNumber = orderNumber;
        }
        public VentilationAggregate() : this("0", "EmptyDate")
        { }

        public void AddServiceReport(ServiceReport serviceReport)
        {
            serviceReports.Add(serviceReport);
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
            return filters;
        }

        public override string ToString()
        {
            return $"{OrderNumber}";
        }

    }
}
