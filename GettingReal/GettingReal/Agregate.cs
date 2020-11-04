using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    public class Agregate
    {
        public ? Operationinfo { get; set; }
        public string ModelNumber { get; set; }
        public DateTime Date { get; set; }
        public string OrderNumber { get; set; }

        public Agregate(string modelNumber, string orderNumber)
        {
            ModelNumber = modelNumber;
            DateTime date = new DateTime();
            Date = date.Date;
            OrderNumber = orderNumber;
        }

    }
}
