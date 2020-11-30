using GettingReal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal.ViewModels
{
    public class VMServiceReport
    {
        private ServiceReport _serviceReport;
        private string _date;

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public VMServiceReport(ServiceReport serviceReport)
        {
            Date = serviceReport.Date;
        }

        public ServiceReport GetServiceReport()
        {
            return this._serviceReport;
        }
    }
}
