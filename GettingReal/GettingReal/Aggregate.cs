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
        
        public List<Filter> filters = new List<Filter>();
        public List<ServiceReport> serviceReports = new List<ServiceReport>();
        public List<Floor> floors;

        public Aggregate(string modelNumber = "0", string orderNumber = "0", Customer customer = null)        
        {
            ModelNumber = modelNumber;
            DateTime date = new DateTime();
            Date = date.Date;
            OrderNumber = orderNumber;
        }



    }
}
