using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    [Serializable]
    public class ServiceReport
    {
        public string Date { get; private set; }

        public ServiceReport(string date = "EmptyDate")
        {
            if (date == "EmptyDate")
            {
                var dateToday = DateTime.Now;
                date = dateToday.ToShortDateString();
            }
            Date = date;
        }
        public ServiceReport() : this("EmptyDate")
        {

        }
    }
}
