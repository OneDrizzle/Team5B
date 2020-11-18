using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal.Models
{
    [Serializable]
    public class VentilationAggregate
    {
        public string InstallDate { get; set; }
        public string OrderNumber { get; set; }
        private string fileName;

        private List<Filter> _filters;
        private List<ServiceReport> _serviceReports;
        private List<Floor> _floors;
        


        public VentilationAggregate(string orderNumber = "0", string fileName = "", string date = "EmptyDate")
        {
            _filters = new List<Filter>();
            _serviceReports = new List<ServiceReport>();
            _floors = new List<Floor>();
            this.fileName = fileName;

            // Stes date to the current date if no date is given
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

        // Adds a new servicereport to the ventilation aggregate
        public void AddServiceReport(ServiceReport serviceReport)
        {
            _serviceReports.Add(serviceReport);
        }

        // gets a list of all servicereports
        public List<ServiceReport> GetListOfServiceReports()
        {
            return _serviceReports;
        }

        // Adds a filter to the servicereport
        public void AddFilter(Filter filter)
        {
            _filters.Add(filter);
        }

        // Retrieves a filter by filter model
        public Filter GetFilter(string model)
        {
            foreach (Filter filter in _filters)
            {
                if (filter.Model == model)
                {
                    return filter;
                }
            }
            return null;
        }

        // Retrieves a list of filters associated with the ventilation aggregate
        public List<Filter> GetListOfFilters()
        {
            return _filters;
        }

        public override string ToString()
        {
            return $"{OrderNumber}";
        }

    }
}
