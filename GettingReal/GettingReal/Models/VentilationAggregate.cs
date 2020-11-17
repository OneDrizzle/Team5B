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


        private List<Filter> _filters;
        private List<ServiceReport> _serviceReports;
        private List<Floor> _floors;


        public VentilationAggregate(string orderNumber = "0", string date = "EmptyDate")
        {
            _filters = new List<Filter>();
            _serviceReports = new List<ServiceReport>();
            _floors = new List<Floor>();

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
            _serviceReports.Add(serviceReport);
        }


        public List<ServiceReport> GetListOfServiceReports()
        {
            return _serviceReports;
        }

        public void AddFilter(Filter filter)
        {
            _filters.Add(filter);
        }

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
