using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    public class Aggregate
    {
        //public ? Operationinfo { get; set; }
        public string ModelNumber { get; set; }
        public DateTime Date { get; private set; }
        public string OrderNumber { get; set; }
        public string fileName { get; set; }

        private List<Filter> filters;
        private List<ServiceReport> serviceReports;
        private List<Floor> floors;

        public Aggregate(string modelNumber = "0", string orderNumber = "0")        
        {
            filters = new List<Filter>();
            serviceReports = new List<ServiceReport>();
            floors = new List<Floor>();

            ModelNumber = modelNumber;
            DateTime date = new DateTime();
            Date = date.Date;
            OrderNumber = orderNumber;
        }

        public void AddFilter(Filter filter)
        {
            filters.Add(filter);
        }

        public List<Filter> GetFilters()
        {
            if (filters == null)
                return null;

            return filters;
        }


    }
}
