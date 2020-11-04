using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    public class ServiceReport
    {
        public DateTime Date { get; set; }
        public ? ServiceData { get; set; }

        public ServiceReport()
        {
            DateTime date = new DateTime();
            Date = date.Date;
        }
    }
}
