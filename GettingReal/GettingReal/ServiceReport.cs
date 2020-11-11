using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    public class ServiceReport
    {
        public string Date { get; private set; }

        public ServiceReport()
        {
            var date = DateTime.Now;
            Date = date.ToShortDateString();
        }
    }
}
